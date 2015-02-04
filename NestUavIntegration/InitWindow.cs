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
        }

        private void NewPacketReceived(object sender, MavlinkPacket packet)
        {
            //For now we just print out the type of message we received.
            Console.WriteLine(packet.Message.ToString());
        }
    }
}
