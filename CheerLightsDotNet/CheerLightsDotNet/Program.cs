using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace CheerLightsDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            var delay = 20000;
            Welcome();

            while (true)
            {
                var color = GetColor();

                Console.WriteLine(DateTime.Now + " :: " + color);

                Sleep(delay);

                Console.WriteLine();
                Console.WriteLine("--------------------------------");
            }
        }

        private static void Sleep(int delay)
        {
            for (var i = delay / 1000; i > 0; i--)
            {
                Console.CursorLeft = 0;
                Console.Write("Waiting " + i + "s");
                System.Threading.Thread.Sleep(1000);
            }
        }

        private static void Welcome()
        {
            Console.WriteLine("C H E E R L I G H T S");
            Console.WriteLine("=====================");
            Console.WriteLine();
        }

        private static string GetColor()
        {
            Console.WriteLine("Requesting color...");
            var request = HttpWebRequest.Create("http://api.thingspeak.com/channels/1417/field/1/last.txt");
            var response = request.GetResponse();
            var colorstring = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return colorstring;
        }
    }
}
