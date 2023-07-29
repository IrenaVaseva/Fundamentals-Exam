using System.Text;
using System.Text.RegularExpressions;

namespace _02._Destination_Mapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string places=Console.ReadLine();
            string pattern = @"(\=|\/)(?<destination>[A-Z][A-Za-z]{2,})\1";
            List<string> listPlaces = new List<string>();

            int travelPoint = 0;

            foreach (Match m in Regex.Matches(places, pattern))
            {
                listPlaces.Add(m.Groups["destination"].Value);
                travelPoint += m.Groups["destination"].Value.Length;
            }
            Console.WriteLine ($"Destinations: {string.Join(", ", listPlaces)}");
            Console.WriteLine($"Travel Points: {travelPoint}");
        }
    }
}