using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MavLink;
using MavLinkNet;
using NEST_App.Models;

namespace CommunicationsLayer
{
    public class NestMavBridge
    {

        private NestManager nest;
        private MavManager mav;

        //Stores the latest message we have received.
        private IDictionary<byte, UasMessage> mavMessageCache;

        public NestMavBridge(NestManager nest, MavManager mav)
        {
            Console.WriteLine("NestMavBridge init");
            this.nest = nest;
            this.mav = mav;
            this.mavMessageCache = new Dictionary<byte, UasMessage>();
            this.SubscribeToMavNetworkConnection();
            this.SubscribeToSignalR();
            //TODO: Move this out 
            this.StartSendTask();
            mav.ArmVehicle();
        }

        private void SubscribeToSignalR()
        {
            this.nest.receivedTargetCommand += GoToCommand;
        }

        private void SubscribeToMavNetworkConnection()
        {   
            this.mav.OnPacketReceived += this.MavlinkStoreGeneric;
        }

        public void MavlinkStoreGeneric(object sender, MavLinkPacket msg)
        {
            mavMessageCache[msg.MessageId] = msg.Message;
        }

        public async void GoToCommand(object sender, CMD_NAV_Target target)
        {

            await this.mav.goToLocation(target.Latitude, target.Longitude);
        }

        public async void StartSendTask()
        {
            while (true)
            {
                //Use await Task to make it asynchronous and not block the thread (the UI thread)
                await Task.Delay(200);
                if (this.mavMessageCache.ContainsKey(33))
                {
                    var gps = (UasGlobalPositionInt)this.mavMessageCache[33];

                    FlightState fs = new FlightState
                    {
                        //The Id = 1 is because NEST sucks
                        Id = 1,
                        Latitude = gps.Lat / (10000000.0),
                        Longitude = gps.Lon / (10000000.0),
                        VelocityX = gps.Vx / 100.0,
                        VelocityY = gps.Vy / 100.0,
                        VelocityZ = gps.Vz / 100.0,
                        Altitude = gps.RelativeAlt / 1000.0,
                        Yaw = gps.Hdg / 100.0,
                        create_date = DateTime.Now,
                        modified_date = DateTime.Now
                    };

                    if(this.mavMessageCache.ContainsKey(147))
                    {
                        var bat = (UasBatteryStatus)this.mavMessageCache[147];
                        fs.BatteryLevel = bat.BatteryRemaining;
                    }

                    await this.nest.sendFlightState(fs);

                    
                }
            }
        }
    }
}
