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

namespace NestUavIntegration
{
    public partial class InitWindow : Form
    {
        private MavNetworkConnection socket;

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        public InitWindow()
        {
            InitializeComponent();
            //Just have the connection in the background for now.
            this.socket = new MavNetworkConnection();
            this.socket.PacketEventHandler += this.NewPacketReceived;
        }


        private void Connect_Click(object sender, EventArgs e)
        {
            string portStr = this.textBox1.Text;
            int portNo = Convert.ToInt32(portStr);
            //Give it the port number we entered.
            this.socket.Connect(portNo);
            infoBox.AppendText("Connected to UDP port " + portNo + "." + Environment.NewLine);

            //This starts the loop in the background.
            this.socket.BeginReceiveTask();
            infoBox.AppendText("Receiving Data... " + Environment.NewLine);

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
            Console.WriteLine(packet.Message.ToString());

            //Process message type and display info on GUI
            //Using old code from QuadLink. 
            //In Progress...
           /* switch (msg.msgid)
            {
                case MAVLINK_MSG_ID_ATTITUDE:
                    mavlink_msg_attitude_decode(&msg, &att);
                    break;
                case MAVLINK_MSG_ID_GLOBAL_POSITION_INT:
                    setGlobalPosition(msg);
                    break;
                case MAVLINK_MSG_ID_HEARTBEAT:
                    compid = msg.compid;
                    mavlink_msg_heartbeat_decode(&msg, &hb);
                    printf("hb base_mode: %d\n", hb.base_mode);
                    break;
                case MAVLINK_MSG_ID_SYS_STATUS:
                    mavlink_msg_sys_status_decode(&msg, &qStatus);
                    break;
                case MAVLINK_MSG_ID_GPS_RAW_INT:
                    mavlink_gps_raw_int_t gpsRaw;
                    mavlink_msg_gps_raw_int_decode(&msg, &gpsRaw);
                    //printf("lat:%d long:%d\n", gpsRaw.lat, gpsRaw.lon);
                    break;
                case MAVLINK_MSG_ID_MISSION_ACK:
                    mavlink_mission_ack_t miss;
                    mavlink_msg_mission_ack_decode(&msg, &miss);
                    //Set ack to 1 if APM received the waypoint
                    //if(miss.type == 1) ack = 1; //Not sure if 1 means received
                    printf("type: %d\n", miss.type);
                    break;
            }*/
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
    }
}
