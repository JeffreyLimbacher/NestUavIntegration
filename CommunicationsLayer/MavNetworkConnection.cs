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
        private IPEndPoint connectionEndPoint;

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

        public MavNetworkConnection()
        {
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
                        mav.ParseBytes(receive.Buffer);
                    }
                });
        }

        /****
         * I don't like these two functions, I prefer the task.run method.
        public void BeginReceive()
        {
            this.shouldReceive = true;
            UdpState udpState = new UdpState();
            udpState.e = this.connectionEndPoint;
            udpState.u = this.connection;
            this.connection.BeginReceive(new AsyncCallback(this.GotReceive), udpState);
        }

        public void GotReceive(IAsyncResult ar)
        {
            UdpState state = (UdpState)(ar.AsyncState);
            IPEndPoint point = state.e;
            UdpClient udp = state.u;
            byte[] data = udp.EndReceive(ar, ref point);
            mav.ParseBytes(data);
            if(shouldReceive)
            {
                this.BeginReceive();
            }
        }*/

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
