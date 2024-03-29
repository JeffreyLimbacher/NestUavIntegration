﻿using System;
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

    public class NetworkConnection//: IMavConnection TODO
    {
        //TODO: Kill the thread when needed
        //TODO: Write out packets
        //TODO: Report errors
        private Mavlink mav;

        private IComms comms;

        //This uses the event delegate defined in MavLink.cs. See that for parameter information (although it should be clear from the method below).
        //This simply gets the packets receives from the Mavlink.cs file and fires another event.
        public PacketReceivedEventHandler PacketEventHandler;

        public MavlinkMessageEventHandler<Msg_attitude> receivedAttitude;
        public MavlinkMessageEventHandler<Msg_global_position_int> receivedGlobalPositionInt;
        public MavlinkMessageEventHandler<Msg_command_ack> receivedAck;

        //This stores the thread that is listening in the background.
        public Task listeningTask;

        public enum Phase
        {
            NotConnected, //Haven't received anything yet.
            Connecting, //Awaiting the param_list and heartbeats
            NotArmed,
            Arming,
            Armed
        }
        /// <summary>
        /// Used to store what phase the connection is in. Similar to a Finite State Automata, but just implemented really simply
        /// DO NOT SET DIRECTLY! Unless you know why you are doing it that way and have a good reason.
        /// </summary>
        private Phase _currentPhase;
        /// <summary>
        /// Readonly access to the current phase
        /// </summary>
        public Phase CurrentPhase
        {
            get { return this._currentPhase; }
        }
        /// <summary>
        /// Private phase used to set the phase. This also emits out an event that the phase was changed, so this is the preferred way to
        /// set the _currentPhase.
        /// </summary>
        private Phase currentPhase
        {
            set
            {
                if(this._currentPhase != value && phaseChangedHandler != null)
                {
                    phaseChangedHandler(this, value);
                }
                this._currentPhase = value;
            }
        }
        /// <summary>
        /// Delegate that is called whenever the phase is changed.
        /// </summary>
        /// <param name="mav">The connection emitting out</param>
        /// <param name="p">The new phase.</param>
        public delegate void PhaseChanged(NetworkConnection mav, Phase p);
        public PhaseChanged phaseChangedHandler;

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

        public NetworkConnection(IComms comms)
        {
            componentId = 0;
            systemId = 0;
            //Wait until we get it from the receive task.
            this.mav = new Mavlink();
            this.mav.PacketReceived += this.PassOnNewPacket;
            this.currentPhase = Phase.NotConnected;
            this.comms = comms;
        }

        public void Connect()
        {
            this.comms.Connect();
        }

        public void BeginReceiveTask()
        {
            //We already have a task running, don't start a new one.
            if (this.listeningTask != null)
            {
                return;
            }
            //Start the task.
            this.listeningTask = Task.Run(async () =>
                {
                    while (true)
                    {
                        await bookKeepingSend();
                        //Receie the connection
                        byte[] data = await this.comms.ReceiveAsync();
                        mav.ParseBytes(data);

                    }
                });
        }

        public async Task bookKeepingSend()
        {
            if (!this.comms.Connected)
            {
                return;
            }
            switch (this._currentPhase)
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
                        //await this.sendParamRequestList();
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

        private DateTime lastHeartbeatTime = DateTime.Now;
        public async Task sendHeartbeat()
        {
            DateTime currentTime = DateTime.Now;
            if ((currentTime - lastHeartbeatTime).Duration().TotalMilliseconds > 100)
            {
                Msg_heartbeat heartbeat = new Msg_heartbeat();
                heartbeat.custom_mode = 0x00060800; //Stolen by packet sniffing Mission Planner's packets
                //Rest are zero, which C# handles for us
                await this.SendMessage(heartbeat);
                lastHeartbeatTime = DateTime.Now;
            }
        }

        private DateTime lastParamRequestTime = DateTime.Now;
        public async Task sendParamRequestList()
        {
            DateTime currentTime = DateTime.Now;
            if((currentTime - lastParamRequestTime).Duration().TotalMilliseconds > 1000)
            {
                Msg_param_request_list list = new Msg_param_request_list();
                list.target_component = 1;
                list.target_system = 1;
                await this.SendMessage(list);
                lastParamRequestTime = DateTime.Now;
            }
        }

        public void processMsg(MavlinkPacket packet)
        {
            MavlinkMessage msg = packet.Message;

            string message = packet.Message.ToString();
            this.currentPhase = Phase.NotArmed;
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
                        var ack = (Msg_command_ack)msg;
                        Console.WriteLine(ack.result);
                        receivedAck(this, (Msg_command_ack)msg);
                    }
                    break;
            }
        }

        public async Task<int> SendMessage(MavlinkMessage msg)
        {
            MavlinkPacket pack = new MavlinkPacket
            {
                Message = msg,
                ComponentId = 0,
                SystemId = 0
            };
            byte[] bytes = mav.Send(pack);
            int sent = await this.comms.SendAsync(bytes, bytes.Length);
            return sent;
        }

        //This just passes on packets.
        protected void PassOnNewPacket(object sender, MavlinkPacket packet)
        {
            this.processMsg(packet);
            //Null checks to make sure that we actually have subscribing methods
            if (PacketEventHandler != null)
            {
                PacketEventHandler(this, packet);
            }
        }

        public async Task<bool> ArmVehicle()
        {
            if (this._currentPhase == Phase.NotArmed)
            {
                var armCmd = new MavLink.Msg_command_long();
                armCmd.command = (ushort)MAV_CMD.MAV_CMD_COMPONENT_ARM_DISARM;
                armCmd.param1 = 1;
                Console.WriteLine("Sending arming message...");
                await this.SendMessage(armCmd);
                return true;
            }
            return false;
        }
    }
}
