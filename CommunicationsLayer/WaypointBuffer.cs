using MavLinkNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationsLayer
{
    public class WaypointBuffer
    {
        private MavManager mav;

        private float[] lon = { -35.363338f, -35.362660f, -35.362679f, -35.362904f };
        private float[] lat = { 149.165301f, 149.165282f, 149.165038f, 149.164724f };

        public WaypointBuffer(MavManager mav)
        {
            this.mav = mav;
        }
        
        //TODO: Get the needed waypoints from NEST
        //Temporarily loading waypoints from an array
        public void PrepareWaypoints(){

            UasMissionCount count = new UasMissionCount()
            {
                TargetSystem = 0,
                TargetComponent = 0,
                Count = (ushort)lon.Length
            };

            //Notify UAV of how many waypoint to expect
            mav.SendMessage(count);
        }

        public void sendWaypoint(int sequence)
        {
            UasMissionItem missionItem = new UasMissionItem()
            {
                TargetSystem = 0,
                TargetComponent = 0,
                Frame = MavFrame.GlobalRelativeAlt,
                Current = (byte)(sequence == 0 ? 1 : 0),
                Command = MavCmd.NavWaypoint,
                Param1 = 0,
                Param2 = 0,
                Param3 = 0,
                Param4 = 0,
                X = lon[sequence],
                Y = lat[sequence],
                Z = 20,
                Seq = (ushort)sequence,
                Autocontinue = (byte)1
            };

            mav.SendMessage(missionItem);
        }
    }
}
