using System;
using System.Numerics;
using System.Text;
using static System.Formats.Asn1.AsnWriter;

namespace _01._World_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string route = Console.ReadLine();
            StringBuilder sbRoute = new StringBuilder(route);

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Travel")
            {
                string[] detailsRoute = input.Split(":").ToArray();
                string command = detailsRoute[0];

                switch (command)
                {
                    case "Add Stop":
                        int index = int.Parse(detailsRoute[1]);
                        string addPoint = detailsRoute[2];
                        AddStop(sbRoute, index, addPoint);
                        break;
                    case "Remove Stop":
                        int startIndex = int.Parse(detailsRoute[1]);
                        int endIndex = int.Parse(detailsRoute[2]);
                        RemoteStop(sbRoute, startIndex, endIndex);
                        break;
                    case "Switch":
                        string oldPoint = detailsRoute[1];
                        string newPoint = detailsRoute[2];
                        SwitchPoint(sbRoute, oldPoint, newPoint);
                        break;
                }
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {sbRoute.ToString()}");
        }

        private static void SwitchPoint(StringBuilder sbRoute, string oldPoint, string newPoint)
        {
            sbRoute.Replace(oldPoint, newPoint);
            Console.WriteLine(sbRoute.ToString());
        }

        private static void RemoteStop(StringBuilder sbRoute, int startIndex, int endIndex)
        {
            if ((startIndex >= 0 && startIndex < sbRoute.Length) && (endIndex >= 0 && endIndex < sbRoute.Length))
            {
                sbRoute.Remove(startIndex, endIndex - startIndex + 1);
            }
            Console.WriteLine(sbRoute.ToString());
        }

        private static void AddStop(StringBuilder sbRoute, int index, string newPoint)
        {
            if (index >= 0 && index < sbRoute.Length)
            {
                sbRoute.Insert(index, newPoint);
            }
            Console.WriteLine(sbRoute.ToString());
        }
    }
}