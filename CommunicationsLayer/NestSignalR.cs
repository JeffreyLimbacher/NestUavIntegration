using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNet.SignalR.Client;
using NEST_App.Models;



namespace CommunicationsLayer
{
    public class NestSignalR
    {

        private static HubConnection hubConnection;
        

        private NestSignalR(IHubProxy vehicleHub)
        {
            //This should never be called
        }

        public static async Task<IHubProxy> getNestConnection(string url)
        {
            if (hubConnection == null)
            {
                hubConnection = new HubConnection(url);
            }
            IHubProxy vehicleHub = hubConnection.CreateHubProxy("VehicleHub");
            hubConnection.GroupsToken = "vehicles";
            
            if (hubConnection.State != ConnectionState.Connected)
            {
                await hubConnection.Start();
            }
            //Join the vehicles group.
            await vehicleHub.Invoke("JoinGroup", "vehicles");
            return vehicleHub;
        }

    }
}
