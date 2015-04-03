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

        private IHubProxy vehicleHub;

        private static HubConnection hubConnection = null;

        public delegate void receivedSignalR<T> (object sender, T message);

        private NestSignalR(IHubProxy vehicleHub)
        {
            this.vehicleHub = vehicleHub;
            //TODO: connect listeners
            vehicleHub.On<FlightState>("flightStateUpdate", fs =>
            {
                Console.Out.WriteLine(fs.Id);
            });
        }

        public void sendFlightState(FlightState fs){
            this.vehicleHub.Invoke("PushFlightStateUpdate", fs);
        }

        public static async Task<NestSignalR> getNestConnection(string url)
        {
            if (hubConnection == null)
            {
                hubConnection = new HubConnection(url);
            }
            IHubProxy vehicleHub = hubConnection.CreateHubProxy("VehicleHub");
            var nestConn = new NestSignalR(vehicleHub);
            if (hubConnection.State != ConnectionState.Connected)
            {
                await hubConnection.Start();
            }
            //Join the vehicles group.
            hubConnection.GroupsToken = "vehicles";
            return nestConn;
        }

    }
}
