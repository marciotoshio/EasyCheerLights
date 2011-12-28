using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.IO.Ports;

namespace CheerLightsDotNet
{
    class Program
    {
        static SerialPort serial;
        static void Main(string[] args)
        {
            var delay = 20000;
            var portName = "COM3";
            var boudRate = 9600;

            Welcome();

            ConnectSerial(portName, boudRate);

            while (true)
            {
                var colorstring = GetColor();
                var colorrgb = Convert(colorstring);

                Console.WriteLine(DateTime.Now + " :: " + colorstring);

                SendColor(colorrgb);

                Sleep(delay);

                Console.WriteLine();
                Console.WriteLine("--------------------------------");
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

        private static string Convert(string colorstring)
        {
            /*
             List of colors from http://www.cheerlights.com/control-cheerlights
             */
            switch (colorstring)
            {
                case "red":
                    return "255,0,0";
                case "green":
                    return "0,255,0";
                case "blue":
                    return "0,0,255";
                case "cyan":
                    return "0,255,255";
                case "white":
                    return "255,255,255";
                case "warmwhite":
                    return "253,245,230";
                case "purple":
                    return "128,0,128";
                case "magenta":
                    return "255,0,255";
                case "yellow":
                    return "255,255,0";
                case "orange":
                    return "255,165,0";
                default:
                    return "0,0,0";
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

        private static void ConnectSerial(string portName, int boudRate)
        {
            serial = new SerialPort(portName, boudRate);
            serial.Open();
        }

        private static void SendColor(string colorrgb)
        {
            serial.WriteLine(colorrgb);
        }
    }
}
