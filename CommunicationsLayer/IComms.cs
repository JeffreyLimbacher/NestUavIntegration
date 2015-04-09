using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationsLayer
{
    interface IComms
    {

        bool Connected { get; }

        /// <summary>
        /// This opens the connection to the specified point. The class should start off connected in
        /// both the serial port case and the udp port case, so the call to this should only be called
        /// if the connection point got disconnected.
        /// </summary>
        bool Connect();

        /// <summary>
        /// Send the specified bytes starting at point offset up until offset+length (exclusive)
        /// </summary>
        /// <param name="data"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        Task<int> SendAsync(byte[] data, int length);

        /// <summary>
        /// Receive the bytes from the connection.
        /// </summary>
        /// <returns></returns>
        async Task<byte[]> ReceiveAsync();

        /// <summary>
        /// Closes the connection with the specified point.
        /// </summary>
        void Close();

    }
}
