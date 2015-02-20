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

        //This stores the thread that is listening in the background.
        public Task listeningTask;

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
            set { 
                if(value >= Byte.MaxValue && value <= Byte.MaxValue)
                {
                    this.systemId = value; 
                }
            }
        }

        public MavNetworkConnection()
        {
            componentId = 0;
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
            if(this.listeningTask != null)
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
                        mav.ParseBytes(receive.Buffer);
                    }
                });
        }

        public void processMsg(MavlinkPacket packet) {
            float roll, pitch, yaw;
            MavlinkMessage msg = packet.Message;

            string message = packet.Message.ToString();

             switch (message)
             {
                 case "Msg_attitude":
                     //roll = msg.Msg_attitude.roll;
                     //UpdateAttitude(roll, pitch, yaw);
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
            if(PacketEventHandler != null)
            {
                PacketEventHandler(this, packet);
            }
        }
    }
}
