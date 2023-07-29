using System.Runtime.ConstrainedExecution;

namespace _03._Plant_Discovery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Plant> dicPlants = new Dictionary<string, Plant>();

            for (int i = 0; i < n; i++)
            {
                string[] details = Console.ReadLine().Split("<->").ToArray();
                string name = details[0];
                int rarity = int.Parse(details[1]);
                List<int> rate = new List<int>();
                Plant newPLant = new Plant(name, rarity, rate);
                dicPlants.Add(name, newPLant);
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Exhibition")
            {
                string[] command = input.Split(new[] { ':', '-' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string plant = command[1].Trim();

                if (!dicPlants.ContainsKey(plant))
                {
                    Console.WriteLine("error");
                    continue;
                }
                switch (command[0])
                {
                    case "Rate":
                        int rating = int.Parse(command[2].Trim());
                        dicPlants[plant].Rating.Add(rating);
                        break;
                    case "Update":
                        int newRarity = int.Parse(command[2].Trim());
                        dicPlants[plant].Rarity = newRarity;
                        break;
                    case "Reset":
                        dicPlants[plant].Rating.RemoveAll(x => x >= 0);
                        break;
                }
            }

            Console.WriteLine("Plants for the exhibition:");
            foreach (var plant in dicPlants)
            {
                double average = 0.00;
                if (plant.Value.Rating.Count > 0)
                {
                    average = plant.Value.Rating.Average();
                }
                Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value.Rarity}; Rating: {average:F2}");
            }
        }
    }

    public class Plant
    {
        public Plant(string name, int rarity, List<int> rating)
        {
            Name = name;
            Rarity = rarity;
            Rating = rating;
        }

        public string Name { get; set; }
        public int Rarity { get; set; }
        public List<int> Rating { get; set; }
    }
}