using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MavLinkNet;

namespace CommunicationsLayer
{
    public class MavManager
    {

        private MavLinkGenericTransport transport;
        public event PacketReceivedDelegate OnPacketReceived;
        public event EventHandler OnReceptionEnded;

        public MavManager(MavLinkGenericTransport transport)
        {
            this.transport = transport;
            this.transport.OnPacketReceived += this.HandlePacketReceived;
            this.transport.OnReceptionEnded += this.HandleReceptionEnded;
        }

        public void SendMessage(UasMessage msg)
        {
            this.transport.SendMessage(msg);
        }

        public void ArmVehicle()
        {
            UasCommandLong m = new UasCommandLong()
            {
                TargetComponent = 0,
                TargetSystem = 0,
                Command = MavCmd.ComponentArmDisarm,
                Param1 = 1.0f
            };

            this.SendMessage(m);
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
