using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;
using CommunicationsLayer;
using MavLink;
using MavLinkNet;
using Microsoft.AspNet.SignalR.Client;

namespace NestUavIntegration
{
    public partial class InitWindow : Form
    {
        private MavManager mav;
        private NestMavBridge bridge;
        private WaypointBuffer wpHandler;

        private NestManager nestManager;

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        public InitWindow()
        {
            InitializeComponent();
            //Just have the connection in the background for now.
           

        }


        private void Connect_Click(object sender, EventArgs e)
        {
            this.mavConnect.Enabled = false;
            string portStr = this.portTb.Text;
            int portNo = Convert.ToInt32(portStr);
            //Give it the port number we entered.
            var trans = new MavLinkUdpTransport()
            {
                UdpListeningPort = portNo,
            };
            infoBox.AppendText("Connected to UDP port " + portNo + "." + Environment.NewLine);
            //this.socket.OnPacketReceived += this.NewPacketReceived;
            //This starts the loop in the background.
            trans.Initialize();
            infoBox.AppendText("Receiving Data... " + Environment.NewLine);
            this.mav = new MavManager(trans);
            this.mav.OnPacketReceived += this.onReceivedHeartbeat;
            this.mav.OnPacketReceived += this.onReceivedStatus;
            this.armButton.Enabled = true;

            this.wpHandler = new WaypointBuffer(mav);          
            this.createBridgeIfPossible();
        }

        private void createBridgeIfPossible()
        {
            if(this.mav != null && this.nestManager != null)
            {
                this.bridge = new NestMavBridge(this.nestManager, this.mav);
            }
        }

        private void InitWindow_Load(object sender, EventArgs e)
        {
            //This allocates a debugging console window to make things easier.
            //Gives us the ease of user input with windows forms with the ease of output of console logging
            //super ghetto tho
            AllocConsole();

            this.FillTypeSelect();
        }

        public void NewPacketReceived(object sender, MavlinkPacket packet)
        {
            if(packet.Message.ToString() == "Msg_heartbeat")
            {

            }
        }

        /// <summary>
        /// Get the Mavlink assembly (which is the CommunicationsLayer project) and list all the
        /// types in the combobox.
        /// </summary>
        private void FillTypeSelect()
        {
            Assembly mavAssem = Assembly.GetAssembly(typeof(MavLinkNet.MavLinkUdpTransport));
            Type[] types = mavAssem.GetTypes();
            foreach(Type type in types) 
            {
                //Filter out non message types.
                if (type.ToString().Contains("Uas"))
                {
                    msgSelect.Items.Add(type);
                }
            }
            
        }

        /// <summary>
        /// Populates the table with labels and a textbox so users can input the values they
        /// want in the message. Currently, it's kind of just not working. It was before, not sure
        /// what changed.
        /// </summary>
        /// <param name="sender">Probably the combobox</param>
        /// <param name="e"></param>
        private void msgSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            Type type = (Type)msgSelect.SelectedItem;
            FieldInfo[] fields = type.GetFields();
            messageLayout.Controls.Clear();
            messageLayout.RowCount = fields.Length;
            for(int i = 0; i < fields.Length; i++)
            {
                FieldInfo info = fields[i];
                TableLayoutPanelCellPosition pos = new TableLayoutPanelCellPosition();
                pos.Row = i;

                //The first column contains the names of the field
                pos.Column = 0;
                Label label = new Label();
                label.Text = info.Name;
                messageLayout.Controls.Add(label);

                //The second column says what type the field is expecting.
                pos.Column = 1;
                Type typeOfField = info.FieldType;
                label = new Label();
                label.Text = typeOfField.ToString();
                messageLayout.Controls.Add(label);

                //Has the textboxes where the users can input the fields.
                pos.Column = 2;
                TextBox tb = new TextBox();
                if(typeOfField.IsValueType)
                {
                    //Instantiate value types, not reference types.
                    tb.Text = Activator.CreateInstance(typeOfField).ToString();
                    //For C# noobies, value types are passed in by value, wheras
                    //reference types are passed in by reference. Like Java, int vs Object
                }
                messageLayout.Controls.Add(tb);
            }
            
        }

        /// <summary>
        /// Build the message from the information inputted in the table.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendMessageButton_Click(object sender, EventArgs e)
        {
            //Gets the type that was selected
            Type type = (Type)msgSelect.SelectedItem;
            FieldInfo[] fields = type.GetFields();
            //Activator instantiates an object of the type selected.
            object t = Activator.CreateInstance(type);
            try
            {
                for (int i = 0; i < fields.Length; i++)
                {
                    //The second column is all the values, but they are string values.
                    TextBox tb = (TextBox)messageLayout.GetControlFromPosition(2, i);
                    string val = tb.Text;
                    FieldInfo field = fields[i];
                    //This converts the string to the type selected. This won't work for all the types.
                    field.SetValue(t, Convert.ChangeType(val, field.FieldType));
                }
                //await socket.SendMessage((MavlinkMessage)t);

                //Inform user about successful message delivery
                infoBox.AppendText("Message sent." + Environment.NewLine);
            }
            catch (Exception ex)
            {
                //Report out error.
                MessageBox.Show("The following error occured while sending the message! Please try again:\n" + ex, "Error!", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Output error to user information box for user reference
                infoBox.AppendText("Failed to send message! Error:" + Environment.NewLine + ex + Environment.NewLine);
            }
        }

        private void ClearInfoBox_Click(object sender, EventArgs e)
        {
            infoBox.Clear();
        }

        private async void armButton_Click(object sender, EventArgs e)
        {

            await this.mav.ArmVehicle();
        }

        private async void nestConnect_Click(object sender, EventArgs e)
        {
            this.nestConnect.Enabled = false;
            IHubProxy nest = await NestSignalR.getNestConnection("http://localhost:53130");

            

            string url = this.nestUrlTextBox.Text;

            this.nestManager = new NestManager(nest, url);

            this.testButton.Enabled = true;

            this.createBridgeIfPossible();

            this.nestManager.LoginToNest();
            bool result = await this.nestManager.RegisterVehicle("SERL1");
            if (result)
            {
                Console.WriteLine("Vehicle successfully registered");
            }
            else
            {
                Console.WriteLine("Something went wrong registering the vehicle");
            }
        }

        private void stateChanged(object sender, NestManager.NestStatus status)
        {
            switch(status)
            {
                case NestManager.NestStatus.NotConnected:
                    this.nestConnect.Enabled = true;
                    break;
                case NestManager.NestStatus.NotLoggedIn:
                case NestManager.NestStatus.Ready:
                    this.nestConnect.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        private async void testButton_Click(object sender, EventArgs e)
        {
            bool worked = await this.nestManager.sendFlightState(new NEST_App.Models.FlightState
            {
                Latitude = 34.242034,
                Longitude = -118.528763,
                BatteryLevel = 1.00,
                Altitude = 400,
                create_date = DateTime.Now,
                modified_date = DateTime.Now,
                Pitch = 0,
                PitchRate = 0,
                Roll = 0,
                RollRate = 0,
                Yaw = 0,
                YawRate = 0,
                VelocityX = 0,
                VelocityY = 0,
                VelocityZ = 0,
                Timestamp = DateTime.Now
            });
            if(worked)
            {
                Console.WriteLine("Flightstate setting worked");
            }
            else
            {
                Console.WriteLine("FlightState setting failed");
            }
        }

        private void onReceivedHeartbeat(object sender, MavLinkPacket pack)
        {
            if(this.InvokeRequired)
            {
                PacketReceivedDelegate d = new PacketReceivedDelegate(this.onReceivedHeartbeat);
                try
                {
                    this.Invoke(d, sender, pack);
                    return;
                }
                catch (ObjectDisposedException e)
                {
                    Console.WriteLine("System ignored a message because it is closing");
                }
            }
            else if (pack.MessageId == 0)
            {
                UasHeartbeat hb = (UasHeartbeat)pack.Message;
                this.vehicleMode.Text = "Disarmed";
                if(hb.BaseMode.HasFlag((MavModeFlag)MavModeFlagDecodePosition.Safety))
                {
                    this.armedLabel.Text = "Armed";
                }
                else
                {
                    this.armedLabel.Text = "Disarmed";
                }

                if (hb.BaseMode.HasFlag((MavModeFlag)MavModeFlagDecodePosition.Auto))
                {
                    this.vehicleMode.Text = "Auto";
                }
                else if (hb.BaseMode.HasFlag((MavModeFlag)MavModeFlagDecodePosition.Guided))
                {
                    this.vehicleMode.Text = "Guided";
                }
                else if (hb.BaseMode.HasFlag((MavModeFlag)MavModeFlagDecodePosition.Stabilize))
                {
                    this.vehicleMode.Text = "Stabilze";
                }
                else
                {
                    this.vehicleMode.Text = "Unknown";
                }
            }
        }

        /// <summary>
        /// Handle any incoming messages related to UAV status information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="pack"></param>
        private void onReceivedStatus(Object sender, MavLinkPacket pack)
        {
            if (this.InvokeRequired)
            {
                PacketReceivedDelegate d = new PacketReceivedDelegate(this.onReceivedStatus);
                try
                {
                    this.Invoke(d, sender, pack);
                    return;
                }
                catch (ObjectDisposedException e)
                {
                    Console.WriteLine("System ignored a message because it is closing");
                }
            }
            else {
                if (pack.MessageId == 30) // attitude
                {
                    UasAttitude attitude = (UasAttitude)pack.Message;

                    //Display IMU Data on Flight State Tab
                    rollTb.Text = String.Format("{0:0.00##}", attitude.Pitch);
                    pitchTb.Text = String.Format("{0:0.00##}", attitude.Pitch);
                    yawTb.Text = String.Format("{0:0.00##}", attitude.Yaw);

                    //Display Speed Data on Flight State Tab
                    rollSpdTb.Text = String.Format("{0:0.00##}", attitude.Rollspeed);
                    pitchSpdTb.Text = String.Format("{0:0.00##}", attitude.Pitchspeed);
                    yawSpdTb.Text = String.Format("{0:0.00##}", attitude.Yawspeed);
                }
                if (pack.MessageId == 33) //global_position_int
                {
                    UasGlobalPositionInt position = (UasGlobalPositionInt)pack.Message;

                    altitudeTb.Text = String.Format("{0:0.00##}", (position.RelativeAlt)/1000);
                }
                if (pack.MessageId == 40)//Waypoint Request
                {
                    UasMissionRequest request = (UasMissionRequest)pack.Message;

                    infoBox.AppendText("Recived request for waypoint " + request.Seq + Environment.NewLine);
                    //this.mav.sendWaypoint(latitudeTb.Text, longitudeTb.Text, true, request.Seq);
                    wpHandler.sendWaypoint(request.Seq);
                }
            } 
        }//End method onReceivedStatus

        private void waypointBtn_Click(object sender, EventArgs e)
        {
            //this.mav.sendWaypoint(latitudeTb.Text,longitudeTb.Text,false,0);
            wpHandler.PrepareWaypoints();
        }

        private async void startMissionBtn_Click(object sender, EventArgs e)
        {
            bool takeoff = await mav.TakeOff(); 

            if (takeoff)
            {
                mav.SetAutoMode();
            }
        }

        private void rtlBtn_Click(object sender, EventArgs e)
        {
            mav.setMode("RTL");
        }
    }
}
