using System.Text;

namespace _03._P_rates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Dictionary<string, Town> dicTowns = new Dictionary<string, Town>();

            while ((input = Console.ReadLine()) != "Sail")
            {
                string[] detailsTown = input.Split("||").ToArray();
                string name = detailsTown[0];
                uint population = uint.Parse(detailsTown[1]);
                int gold = int.Parse(detailsTown[2]);

                if (!dicTowns.ContainsKey(name))
                {
                    Town newTown = new Town(name, population, gold);
                    dicTowns.Add(name, newTown);
                }
                else
                {
                    dicTowns[name].Population += population;
                    dicTowns[name].Gold += gold;
                }
            }

            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split("=>").ToArray();
                string city = command[1];

                switch (command[0])
                {
                    case "Plunder":
                        uint popul = uint.Parse(command[2]);
                        int goldPl = int.Parse(command[3]);
                        Plunder(dicTowns, city, popul, goldPl);
                        break;
                    case "Prosper":
                        int goldPr = int.Parse(command[2]);
                        Prosper(dicTowns, city, goldPr);
                        break;
                }
            }

            if (dicTowns.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {dicTowns.Count} wealthy settlements to go to:");
                foreach (var town in dicTowns)
                {
                    Console.WriteLine($"{town.Key} -> Population: {town.Value.Population} citizens, Gold: {town.Value.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }

        private static void Prosper(Dictionary<string, Town> dicTowns, string city, int goldPr)
        {
            if (goldPr < 0)
            {
                Console.WriteLine("Gold added cannot be a negative number!");
            }
            else
            {
                dicTowns[city].Gold += goldPr;
                Console.WriteLine($"{goldPr} gold added to the city treasury. {city} now has {dicTowns[city].Gold} gold.");
            }
        }

        private static void Plunder(Dictionary<string, Town> dicTowns, string city, uint popul, int goldPl)
        {
            Console.WriteLine($"{city} plundered! {goldPl} gold stolen, {popul} citizens killed.");
            dicTowns[city].Population -= popul;
            dicTowns[city].Gold -= goldPl;

            if (dicTowns[city].Population <= 0 || dicTowns[city].Gold <= 0)
            {
                Console.WriteLine($"{city} has been wiped off the map!");
                dicTowns.Remove(city);
            }
        }
    }

    public class Town
    {
        public Town(string name, uint population, int gold)
        {
            Name = name;
            Population = population;
            Gold = gold;
        }

        public string Name { get; set; }
        public uint Population { get; set; }
        public int Gold { get; set; }

    }
}