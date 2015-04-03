using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MavLink;

namespace CommunicationsLayer
{
    interface IMavConnection
    {
        enum Phase
        {
            NotConnected, //Haven't received anything yet.
            Connecting, //Awaiting the param_list and heartbeats
            NotArmed,
            Arming,
            Armed
        }

        Phase CurrentPhase
        {
            get;
        }

        int componentID
        {
            get;
            set;
        }
        int systemID
        {
            get;
            set;
        }

        //Establish a connection with the vehicle
        void Connect();

        //Arm the vehicle motors to enable movement
        void armVehicle();

        //Command the vehicle to travel to the specified waypoint
        void goToWP();

        //Return vehicle to starting position
        void returnToLaunch();

        //Send a specific message to the vehicle
        async Task<int> SendMessage(MavlinkMessage msg);
    }
}
