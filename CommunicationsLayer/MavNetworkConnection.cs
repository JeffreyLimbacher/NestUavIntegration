using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace CommunicationsLayer
{
    class MavNetworkConnection : IComms
    {

        public bool Connected
        {
            get
            {
                return this.connectionEndPoint != null;
            }
        }

        private byte[] tempStore;

        private UdpClient client;
        private IPEndPoint connectionEndPoint;

        public MavNetworkConnection(int port)
        {
            //IPAddress.Any means we are going to open a UDP port and just listen to any messages coming in.
            IPAddress addr = IPAddress.Any;
            //Open new IP Address with the any ip address and the port
            IPEndPoint ep = new IPEndPoint(addr, port);

            this.client = new UdpClient(ep);
        }

        public bool Connect()
        {
            if (this.connectionEndPoint == null)
            {
                //This might set the connectionEndPoint to not null, so falling
                //through to the return makes sense if it passes the above if statement.
                this.tempStore = this.client.Receive(ref this.connectionEndPoint);
            }
            return this.connectionEndPoint == null;
        }

        public Task<int> SendAsync(byte[] data, int length)
        {
            if(this.connectionEndPoint == null)
            {
                return new Task<int>(-1);
            }
            return this.client.SendAsync(data, length, this.connectionEndPoint);
        }

        public async Task<byte[]> ReceiveAsync()
        {
            UdpReceiveResult recv = await this.client.ReceiveAsync();
            if(this.connectionEndPoint == null)
            {
                this.connectionEndPoint = recv.RemoteEndPoint;
            }
            byte[] toRet = recv.Buffer;
            if(tempStore != null)
            {
                //Shoot, we have to return the temporary buffer back that was populated in the connect call
                //Make a new array that can fit all the old data
                byte[] temp = new byte[toRet.Length + this.tempStore.Length];
                //Copy over the temporary buffer to the new one
                Array.Copy(this.tempStore, temp, this.tempStore.Length);
                //Copy over the udp receive result into the temporary one, but start at where the tempStore data ends.
                Array.Copy(toRet, 0, temp, this.tempStore.Length, toRet.Length);
                //For the return
                toRet = temp;
                //we are done with this data.
                this.tempStore = null;
            }
            return recv.Buffer;
        }

        public void Close()
        {
            this.client.Close();
            this.connectionEndPoint = null;
        }
    }
}
