using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MavLinkNet;

namespace CommunicationsLayer
{
    public class MavLinkConnection
    {

        private MavLinkGenericTransport transport;
        public event PacketReceivedDelegate OnPacketReceived;
        public event EventHandler OnReceptionEnded;

        public MavLinkConnection(MavLinkGenericTransport transport)
        {
            this.transport = transport;
            this.transport.OnPacketReceived += this.HandlePacketReceived;
            this.transport.OnReceptionEnded += this.HandleReceptionEnded;
        }

        private void HandlePacketReceived(object sender, MavLinkPacket e)
        {
            if (OnPacketReceived != null) OnPacketReceived(sender, e);
        }

        private void HandleReceptionEnded(object sender, EventArgs e)
        {
            if (OnReceptionEnded != null) OnReceptionEnded(this, EventArgs.Empty);
        }
    }
}
