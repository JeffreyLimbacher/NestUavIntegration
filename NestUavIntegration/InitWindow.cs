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
        private MavNetworkConnection connection;

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        public InitWindow()
        {
            InitializeComponent();
            //Just have the connection in the background for now.
            this.connection = new MavNetworkConnection();
            this.connection.PacketEventHandler += this.NewPacketReceived;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string portStr = this.textBox1.Text;
            int portNo = Convert.ToInt32(portStr);
            //Give it the port number we entered.
            this.connection.Connect(portNo);
            //This starts the loop in the background.
            this.connection.BeginReceiveTask();

        }

        private void InitWindow_Load(object sender, EventArgs e)
        {
            //This allocates a debugging console window to make things easier.
            //Gives us the ease of user input with windows forms with the ease of output of console logging
            //super ghetto tho
            AllocConsole();

            this.fillTypeSelect();
        }

        private void NewPacketReceived(object sender, MavlinkPacket packet)
        {
            //For now we just print out the type of message we received.
            Console.WriteLine(packet.Message.ToString());
        }

        /// <summary>
        /// Get the Mavlink assembly (which is the CommunicationsLayer project) and list all the
        /// types in the combobox.
        /// </summary>
        private void fillTypeSelect()
        {
            Assembly mavAssem = Assembly.GetAssembly(typeof(Mavlink));
            Type[] types = mavAssem.GetTypes();
            typeSelect.Items.AddRange(types);
        }

        /// <summary>
        /// Populates hte table with labels and a textbox so users can input the values they
        /// want in the message. Current, it's kind of just not working. It was before, not sure
        /// what changed.
        /// </summary>
        /// <param name="sender">Probably the combobox</param>
        /// <param name="e"></param>
        private void typeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            Type type = (Type)typeSelect.SelectedItem;
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
        private void sendMessageButton_Click(object sender, EventArgs e)
        {
            //Gets the type that was selected
            Type type = (Type)typeSelect.SelectedItem;
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
            }
            catch (Exception ex)
            {
                //TODO: Report out error in the GUI
                //Report out error.
                Console.WriteLine(ex);
            }
        }
    }
}
