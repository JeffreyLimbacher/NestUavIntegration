using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationsLayer
{
    public class NestManager
    {

        private NestSignalR sigR;
        private string url;

        

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

        public NestManager(NestSignalR signalRConnection, string url)
        {
            this._State = NestStatus.NotLoggedIn;
            this.sigR = signalRConnection;
            this.url = url;
        }

        public async void loginToNest(string callsign)
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
            }
            //Do error reporting here.
        }



        public HttpWebRequest buildDefaultRequest(string location,  string method = "GET")
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(this.url+location);
            req.UserAgent = "NestUavIntegration";
            req.Method = method;
            return req;
        }
    }
}
