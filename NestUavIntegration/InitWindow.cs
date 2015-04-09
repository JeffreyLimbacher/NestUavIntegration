﻿using System;
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

namespace NestUavIntegration
{
    public partial class InitWindow : Form
    {
        private NetworkConnection socket;
        private NestMavBridge bridge;

        private NestManager nestManager;

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        public InitWindow()
        {
            InitializeComponent();
            //Just have the connection in the background for now.
           

        }


        private async void Connect_Click(object sender, EventArgs e)
        {
            string portStr = this.textBox1.Text;
            int portNo = Convert.ToInt32(portStr);
            //Give it the port number we entered.
            this.socket = new NetworkConnection(new MavNetworkConnection(portNo));
            infoBox.AppendText("Connected to UDP port " + portNo + "." + Environment.NewLine);
            this.socket.PacketEventHandler += this.NewPacketReceived;
            //This starts the loop in the background.
            this.socket.BeginReceiveTask();
            infoBox.AppendText("Receiving Data... " + Environment.NewLine);

            this.armButton.Enabled = true;
        }

        private async void ipEndPointReceived(object sender, EventArgs e)
        {
            Msg_request_data_stream req = new Msg_request_data_stream();
            req.target_system = 1;
            req.target_component = 1;
            req.req_message_rate = 1;
            req.start_stop = 1;
            req.req_stream_id = (byte)MAV_DATA_STREAM.MAV_DATA_STREAM_ALL;

            await this.socket.SendMessage(req);
        }

        private void InitWindow_Load(object sender, EventArgs e)
        {
            //This allocates a debugging console window to make things easier.
            //Gives us the ease of user input with windows forms with the ease of output of console logging
            //super ghetto tho
            AllocConsole();

            this.FillTypeSelect();
        }

        private void NewPacketReceived(object sender, MavlinkPacket packet)
        {
            //For now we just print out the type of message we received.
            //Console.WriteLine(packet.Message.ToString());
        }

        /// <summary>
        /// Get the Mavlink assembly (which is the CommunicationsLayer project) and list all the
        /// types in the combobox.
        /// </summary>
        private void FillTypeSelect()
        {
            Assembly mavAssem = Assembly.GetAssembly(typeof(Mavlink));
            Type[] types = mavAssem.GetTypes();
            foreach(Type type in types) 
            {
                //Filter out non message types.
                if (type.ToString().Contains("Msg_"))
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
        private async void SendMessageButton_Click(object sender, EventArgs e)
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
                await socket.SendMessage((MavlinkMessage)t);

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

            bool canSend = await this.socket.ArmVehicle();
            //TODO: report error if cansend is false
        }

        private async void nestConnect_Click(object sender, EventArgs e)
        {
            this.nestConnect.Enabled = false;
            NestSignalR nest = await NestSignalR.getNestConnection("http://localhost:53130");

            

            string url = this.nestUrlTextBox.Text;

            this.nestManager = new NestManager(nest, url);

            this.testButton.Enabled = true;
            
            if (this.socket != null)
            {
                this.bridge = new NestMavBridge(this.nestManager, this.socket);
            }

            this.nestManager.LoginToNest();
            bool result = await this.nestManager.RegisterVehicle("JEFF22");
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
    }
}
