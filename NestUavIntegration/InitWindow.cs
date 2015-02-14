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

        private void fillTypeSelect()
        {
            Assembly mavAssem = Assembly.GetAssembly(typeof(Mavlink));
            Type[] types = mavAssem.GetTypes();
            typeSelect.Items.AddRange(types);
        }

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

                pos.Column = 0;
                Label label = new Label();
                label.Text = info.Name;
                messageLayout.Controls.Add(label);

                pos.Column = 1;
                Type typeOfField = info.FieldType;
                label = new Label();
                label.Text = typeOfField.ToString();
                messageLayout.Controls.Add(label);

                pos.Column = 2;
                TextBox tb = new TextBox();
                if(typeOfField.IsValueType)
                {
                    tb.Text = Activator.CreateInstance(typeOfField).ToString();
                }
                messageLayout.Controls.Add(tb);
            }
            
        }

        private void sendMessageButton_Click(object sender, EventArgs e)
        {
            Type type = (Type)typeSelect.SelectedItem;
            FieldInfo[] fields = type.GetFields();
            object t = Activator.CreateInstance(type);
            for(int i = 0; i < fields.Length; i++)
            {
                TextBox tb = (TextBox)messageLayout.GetControlFromPosition(2, i);
                string val = tb.Text;
                FieldInfo field = fields[i];
                field.SetValue(t, Convert.ChangeType(val, field.FieldType));
            }

        }
    }
}
