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

        public async Task<bool> goToLocation(double lat, double lon)
        {
            bool result = await TakeOff();
            
            if(result)
            {

                UasMissionItem cmd = new UasMissionItem()
                {
                    Frame = MavFrame.GlobalRelativeAlt,
                    Current = (byte)1,
                    Autocontinue = (byte)1,
                    Command = MavCmd.NavWaypoint,
                    Param3 = 10,
                    Param4 = 0,
                    X = (float)(lat * 1e7),
                    Y = (float)(lon * 1e7),
                    Z = 1500 //Ignore the one in target, probably way too high.
                };

                this.SendMessage(cmd);
            }
            return result;
        }

        public async Task<bool> ArmVehicle()
        {
            var hb = (UasHeartbeat)this.transport.UavState.Get("Heartbeat");
            if(((int)hb.BaseMode & (int)MavModeFlag.SafetyArmed) == 0)
            {
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

                return true;
            }
            return true;

        }

        public bool SetAutoMode()
        {
            UasSetMode mode = new UasSetMode()
            {
                BaseMode = (byte)MavModeFlagDecodePosition.CustomMode,
                CustomMode = 3 //Auto Mode
            };
            this.SendMessage(mode);

            return true;
        }


        public async Task<bool> TakeOff()
        {
            bool armed = await this.ArmVehicle();
            if (armed)
            {
                UasCommandLong armMsg = new UasCommandLong()
                {
                    TargetComponent = 0,
                    TargetSystem = 0,
                    Command = MavCmd.ComponentArmDisarm,
                    Param1 = 1.0f
                };

                this.SendMessage(armMsg);

                await Task.Delay(5000); //Need to give APM time to initialize
                //Only needs to be done one time

                UasCommandLong takeOff = new UasCommandLong()
                {
                    TargetComponent = 0,
                    TargetSystem = 0,
                    Command = MavCmd.NavTakeoff,
                    Param7 = 20,
                };

                this.SendMessage(takeOff);
            }
            return true;
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
