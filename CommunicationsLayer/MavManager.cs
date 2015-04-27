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

        public async Task ArmVehicle()
        {
            //First disarm so we can switch to auto
            UasCommandLong armMsg = new UasCommandLong()
            {
                TargetComponent = 0,
                TargetSystem = 0,
                Command = MavCmd.ComponentArmDisarm,
                Param1 = 0.0f
            };

            this.SendMessage(armMsg);

            await Task.Delay(100);

            UasSetMode mode = new UasSetMode()
            {
                BaseMode = (byte)MavModeFlagDecodePosition.Safety,
                CustomMode = 0,
            };
            this.SendMessage(mode);

            await Task.Delay(100);

            mode = new UasSetMode()
            {
                BaseMode = (byte)MavModeFlagDecodePosition.CustomMode,
                CustomMode = 4
            };
            this.SendMessage(mode);

            await Task.Delay(100);

            armMsg = new UasCommandLong()
            {
                TargetComponent = 0,
                TargetSystem = 0,
                Command = MavCmd.ComponentArmDisarm,
                Param1 = 1.0f
            };

            this.SendMessage(armMsg);

            await Task.Delay(100);

            UasCommandLong takeOff = new UasCommandLong()
            {
                TargetComponent = 0,
                TargetSystem = 0,
                Command = MavCmd.NavTakeoff,
                Param7 = 20,
            };

            this.SendMessage(takeOff);
            
        }

        private void HandlePacketReceived(object sender, MavLinkPacket e)
        {
            UasCommandAck ack = e.Message as UasCommandAck;
            if(ack != null)
            {
                Console.WriteLine("Ack reveied: Command :" + ack.Command + " Result: " + ack.Result);
            }
            UasHeartbeat hb = e.Message as UasHeartbeat;
            if(hb != null)
            {
                Console.WriteLine("Received Heartbeat: Base Mode:" + hb.BaseMode + "Custome Mode:" + hb.CustomMode);
            }
            if (OnPacketReceived != null) OnPacketReceived(sender, e);
        }

        private void HandleReceptionEnded(object sender, EventArgs e)
        {
            if (OnReceptionEnded != null) OnReceptionEnded(this, EventArgs.Empty);
        }
    }
}
