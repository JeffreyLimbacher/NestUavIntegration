using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NEST_App.Models;
using Newtonsoft.Json;

namespace CommunicationsLayer
{
    public class NestManager
    {

        private NestSignalR sigR;
        private string url;
        private UAV uav;
        

        public enum NestStatus
        {
            NotConnected,
            NotLoggedIn,
            Ready
        };
        public EventHandler<NestStatus> stateChanged;
        private NestStatus _state;
        public NestStatus State
        {
            get { return _state; }
        }
        protected NestStatus _State
        {
            get { return _state; }
            set
            {
                _state = value;
                if (stateChanged != null)
                {
                    stateChanged(this, _state);
                }
            }
        }

        private bool setFlightStateDb = false;

        public NestManager(NestSignalR signalRConnection, string url)
        {
            this._State = NestStatus.NotLoggedIn;
            this.sigR = signalRConnection;
            this.url = url;
        }

        public async void LoginToNest()
        {
            //This username is stored in the database automatically
            HttpWebRequest req = this.buildDefaultRequest("/login", "POST");
            string queryParam = "username=NestUavIntegration";
            byte[] dataStream = Encoding.UTF8.GetBytes(queryParam);
            req.ContentLength = dataStream.Length;

            //Send out the username
            Stream str = await req.GetRequestStreamAsync();
            await str.WriteAsync(dataStream, 0, dataStream.Length);
            str.Close();

            //Get the response
            HttpWebResponse response = (HttpWebResponse)await req.GetResponseAsync();
            if(response.StatusCode == HttpStatusCode.OK) {
                this._State = NestStatus.Ready;
                Console.WriteLine("Logged into NEST");
            }
            //Do error reporting here.
        }

        public async Task<bool> RegisterVehicle(string callsign)
        {
            HttpWebRequest req = this.buildDefaultRequest("/api/uavs/adduavwithautoconfig", "POST");
            UAV uav = new UAV
            {
                Callsign = callsign,
                NumDeliveries = 0,
                Mileage = 0,
                create_date = DateTime.Now,
                modified_date = DateTime.Now,
                MaxVelocity = 20,
                MaxAcceleration = 20,
                MaxVerticalVelocity = 20,
                UpdateRate = 20,
                CruiseAltitude = 400,
                MinDeliveryAlt = 200,
                isActive = true,
                estimated_workload = 0,
            };
            
            string uavJson = JsonConvert.SerializeObject(uav);
            byte[] uavBytes = Encoding.ASCII.GetBytes(uavJson);

            Stream str = await req.GetRequestStreamAsync();
            await str.WriteAsync(uavBytes, 0, uavBytes.Length);
            str.Close();

            HttpWebResponse response = (HttpWebResponse)await req.GetResponseAsync();
            StreamReader resStr = new StreamReader(response.GetResponseStream());
            string jsonResponse = await resStr.ReadToEndAsync();
            this.uav = JsonConvert.DeserializeObject<UAV>(jsonResponse);
            bool worked = response.StatusCode == HttpStatusCode.OK;
            return worked;
        }

        public async Task<bool> sendFlightState(FlightState fs)
        {
            if(this.uav == null)
            {
                return false;
            }
            fs.UAVId = this.uav.Id;
            if (this.setFlightStateDb)
            {
                this.sigR.sendFlightState(fs);
                return true;
            }
            else
            {
                HttpWebRequest req = this.buildDefaultRequest("/api/flightstate", "POST");
                Stream stream = await req.GetRequestStreamAsync();
                await writeToStream<FlightState>(fs, stream);
                stream.Close();

                HttpWebResponse res = (HttpWebResponse)await req.GetResponseAsync();

                bool valid = res.StatusCode == HttpStatusCode.OK;
                this.setFlightStateDb = valid;
                res.Close();
                return valid;
            }
        }


        private async Task writeToStream<T>(T obj, Stream str)
        {
            string objStr = JsonConvert.SerializeObject(obj);
            byte[] objBytes = Encoding.ASCII.GetBytes(objStr);
            await str.WriteAsync(objBytes,0, objBytes.Length);
        }

        public HttpWebRequest buildDefaultRequest(string controllerAction,  string method = "GET")
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(this.url+controllerAction);
            req.UserAgent = "NestUavIntegration";
            req.Method = method;
            req.ContentType = "application/json";
            return req;
        }
    }
}
