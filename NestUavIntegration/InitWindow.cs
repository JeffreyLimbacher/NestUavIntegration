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
            this.connection = new MavNetworkConnection();
            this.connection.PacketEventHandler += this.NewPacketReceived;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string portStr = this.textBox1.Text;
            int portNo = Convert.ToInt32(portStr);
            this.connection.Connect(portNo);
            this.connection.BeginReceiveTask();

        }

        private void InitWindow_Load(object sender, EventArgs e)
        {
            AllocConsole();
        }

        private void NewPacketReceived(object sender, MavlinkPacket packet)
        {
            Console.WriteLine(packet.Message.ToString());
        }
    }
}
