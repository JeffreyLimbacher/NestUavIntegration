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

        private Mavlink mav;
        private UdpClient connection;
        private IPEndPoint connectionEndPoint;

        public PacketReceivedEventHandler PacketEventHandler;

        public Task listeningTask;

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
            IPAddress addr = IPAddress.Any;
            this.connectionEndPoint = new IPEndPoint(addr, port);
            this.connection = new UdpClient(this.connectionEndPoint);
        }

        public void BeginReceiveTask()
        {
            if(this.listeningTask != null)
            {
                return;
            }
            this.listeningTask = Task.Run(async () =>
                {
                    while (true)
                    {
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

        protected void PassOnNewPacket(object sender, MavlinkPacket packet)
        {
            if(PacketEventHandler != null)
            {
                PacketEventHandler(this, packet);
            }
        }

        protected class UdpState
        {
            public UdpState()
            {

            }
            public UdpClient u;
            public IPEndPoint e; 
        }
        
    }
}
