using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using MavLink;

namespace CommunicationsLayer
{

    public delegate void MavlinkMessageEventHandler<T>(object sender, T message);

    public class MavNetworkConnection
    {
        //TODO: Kill the thread when needed
        //TODO: Write out packets
        //TODO: Report errors
        private Mavlink mav;
        //The UdpClient is how we are going to receive messages from the SITL.
        private UdpClient connection;
        private volatile IPEndPoint connectionEndPoint;
        private volatile Boolean gotEndPoint;

        //This uses the event delegate defined in MavLink.cs. See that for parameter information (although it should be clear from the method below).
        //This simply gets the packets receives from the Mavlink.cs file and fires another event.
        public PacketReceivedEventHandler PacketEventHandler;

        public MavlinkMessageEventHandler<Msg_attitude> receivedAttitude;
        public MavlinkMessageEventHandler<Msg_global_position_int> receivedGlobalPositionInt;
        public MavlinkMessageEventHandler<Msg_command_ack> receivedAck;

        public EventHandler receivedIpEndPoint;

        //This stores the thread that is listening in the background.
        public Task listeningTask;

        enum Phase
        {
            NotConnected, //Haven't received anything yet.
            Connecting, //Awaiting the param_list and heartbeats
            NotArmed,
            Arming,
            Armed
        }
        private Phase currentPhase;

        //Leftover bool. Maybe can be used to kill the task.
        private bool shouldReceive;
        public bool ShouldReceive
        {
            get { return shouldReceive; }
            set { this.shouldReceive = value; }
        }
        private int componentId;
        public int ComponentId
        {
            get { return componentId; }
            set
            {
                if (value >= Byte.MaxValue && value <= Byte.MaxValue)
                {
                    this.componentId = value;
                }
            }
        }
        private int systemId;
        public int SystemId
        {
            get { return systemId; }
            set
            {
                if (value >= Byte.MaxValue && value <= Byte.MaxValue)
                {
                    this.systemId = value;
                }
            }
        }

        public MavNetworkConnection()
        {
            componentId = 0;
            systemId = 0;
            //Wait until we get it from the receive task.
            this.gotEndPoint = false;
            this.mav = new Mavlink();
            this.mav.PacketReceived += this.PassOnNewPacket;
        }

        public void Connect(int port)
        {
            //IPAddress.Any means we are going to open a UDP port and just listen to any messages coming in.
            IPAddress addr = IPAddress.Any;
            //Open new IP Address with the any ip address and the port
            this.connectionEndPoint = new IPEndPoint(addr, port);

            this.connection = new UdpClient(this.connectionEndPoint);
        }

        public void BeginReceiveTask()
        {
            //We already have a task running, don't start a new one.
            if (this.listeningTask != null)
            {
                return;
            }
            //Start the task. Async for whatever reason. Honestly, no point.
            this.listeningTask = Task.Run(async () =>
                {
                    while (true)
                    {
                        //Receie the connection
                        UdpReceiveResult receive = await this.connection.ReceiveAsync();
                        if (!this.gotEndPoint)
                        {
                            this.connectionEndPoint = receive.RemoteEndPoint;
                            this.gotEndPoint = true;
                        }
                        if (this.receivedIpEndPoint != null)
                        {

                            this.receivedIpEndPoint(this, null);
                            //Get rid of the events, aka only fire this once for people subscribed to it.
                            this.receivedIpEndPoint = null;
                            //This is in its own if statement because people might subscribe after we get the endpoint.
                        }
                        mav.ParseBytes(receive.Buffer);

                    }
                });
        }

        public async Task bookKeepingSend()
        {
            if (!this.gotEndPoint)
            {
                return;
            }
            switch (this.currentPhase)
            {
                case Phase.Armed:
                case Phase.NotArmed:
                    {
                        await this.sendHeartbeat();
                        break;
                    }
                case Phase.Connecting:
                    {
                        await this.sendHeartbeat();
                        await this.sendParamRequestList();
                        break;
                    }
                case Phase.NotConnected:
                    {

                        break;
                    }
                default:
                    break;

            }
        }

        public async Task sendHeartbeat()
        {
            Msg_heartbeat heartbeat = new Msg_heartbeat();
            heartbeat.custom_mode = 0x00060800; //Stolen by packet sniffing Mission Planner's packets
            //Rest are zero, which C# handles for us
            await this.SendMessage(heartbeat);
        }

        private DateTime lastTimeSend = DateTime.Now;
        public async Task sendParamRequestList()
        {
            DateTime currentTime = DateTime.Now;
            if(lastTimeSend == null || (currentTime - lastTimeSend).Duration().TotalMilliseconds > 1000)
            {
                Msg_param_request_list list = new Msg_param_request_list();
                list.target_component = 1;
                list.target_system = 1;
                await this.SendMessage(list);
                lastTimeSend = DateTime.Now;
            }
        }

        public void processMsg(MavlinkPacket packet)
        {
            float roll, pitch, yaw;
            MavlinkMessage msg = packet.Message;

            string message = packet.Message.ToString();

            switch (message)
            {
                case "MavLink.Msg_attitude":
                    if (receivedAttitude != null)
                    {
                        receivedAttitude(this, (Msg_attitude)msg);
                    }
                    break;
                case "MavLink.Msg_global_position_int":
                    if (receivedGlobalPositionInt != null)
                    {
                        receivedGlobalPositionInt(this, (Msg_global_position_int)msg);
                    }
                    break;
                case "Mavlink.Msg_command_ack":
                    if (receivedAck != null)
                    {
                        receivedAck(this, (Msg_command_ack)msg);
                    }
                    break;
                case "Mavlink.param_value":
                    this.currentPhase = Phase.NotArmed;
                    break;
            }
        }

        public async Task<int> SendMessage(MavlinkMessage msg)
        {
            byte[] bytes = mav.Serialize(msg, this.componentId, this.systemId);
            int sent = await this.connection.SendAsync(bytes, bytes.Length, this.connectionEndPoint);
            return sent;
        }

        //This just passes on packets.
        protected void PassOnNewPacket(object sender, MavlinkPacket packet)
        {
            //Null checks to make sure that we actually have subscribing methods
            if (PacketEventHandler != null)
            {
                PacketEventHandler(this, packet);
            }
        }
    }
}
