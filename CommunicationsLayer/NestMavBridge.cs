using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MavLink;
using NEST_App.Models;

namespace CommunicationsLayer
{
    public class NestMavBridge
    {

        private NestSignalR signalr;
        private MavNetworkConnection mav;

        //Stores the latest message we have received.
        private IDictionary<string, object> mavMessageCache;

        public NestMavBridge(NestSignalR signalr, MavNetworkConnection mav)
        {
            this.signalr = signalr;
            this.mav = mav;
            this.mavMessageCache = new Dictionary<string, object>();
            this.subscribeToMavNetworkConnection();

            this.startSendTask();
        }

        private void subscribeToMavNetworkConnection()
        {
            //For now just store attitude and the global position integers
            this.mav.receivedAttitude += this.mavlinkStoreGeneric;
            this.mav.receivedGlobalPositionInt += this.mavlinkStoreGeneric;
        }

        public void mavlinkStoreGeneric<T>(object sender, T msg)
        {
            //the msg.toString should give the message time
            mavMessageCache[msg.ToString()] = msg;
        }

        public async void startSendTask()
        {
            while (true)
            {
                //Use await Task to make it asynchronous and not block the thread (the UI thread)
                await Task.Delay(200);
                if (this.mavMessageCache.ContainsKey("MavLink.Msg_global_position_int"))
                {
                    Console.WriteLine("flight state being sent");
                    var gps = (Msg_global_position_int)this.mavMessageCache["MavLink.Msg_global_position_int"];

                    FlightState fs = new FlightState
                    {
                        //The Id = 1 is because NEST sucks
                        Id = 1,
                        Latitude = gps.lat / (10000000.0),
                        Longitude = gps.lon / (10000000.0),
                        VelocityX = gps.vx / 100.0,
                        VelocityY = gps.vy / 100.0,
                        VelocityZ = gps.vz / 100.0,
                        Altitude = gps.alt / 1000.0,
                        Yaw = gps.hdg / 100.0
                    };
                    this.signalr.sendFlightState(fs);
                }
            }
        }
    }
}
