namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Plant> plants = new List<Plant>(); // създаване на лист от обекти
            int plantNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < plantNumber; i++)
            {
                string[] plantType = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries); // сплитване на данни
                string plantName = plantType[0];
                double plantRarity = double.Parse(plantType[1]);

                Plant plant = plants.FirstOrDefault(p => p.Name == plantName); // проверявам дали има такъв обект в колекцията от растения 

                if (plant != null) // ако има презаписвам реиртито с новото
                {
                    plant.Rarity = plantRarity;
                }
                else // ако няма правя нов обект и го записвам в колекцията от обекти
                {
                    Plant newPlant = new Plant(plantName, plantRarity);
                    plants.Add(newPlant);
                }
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Exhibition") // цикъл до ehibition input
            {
                string[] cmdArgs = command.Split(":", StringSplitOptions.RemoveEmptyEntries); //сплитвам данни
                string commandType = cmdArgs[0];
                string[] cmdData = cmdArgs[1].Split("-", StringSplitOptions.RemoveEmptyEntries);
                string plantName = cmdData[0];


                if (commandType == "Rate") // ако типа е рейт
                {
                    Plant currPlant = plants.FirstOrDefault(p => p.Name == plantName); // проверявам дали има такъв обект в колекцията от растения => тук се чупи, връща нул а не трябва
                    double rating = double.Parse(cmdData[1]);

                    if (currPlant == null) // ако няма такова растения врищам ерор
                    {
                        Console.WriteLine("error");
                    }
                    else // ако им добавям рейтинга му в лист
                    {
                        currPlant.AddRating(rating);
                    }
                }
                else if (commandType == "Update")
                {
                    Plant currPlant = plants.FirstOrDefault(p => p.Name == plantName);// проверявам дали има такъв обект в колекцията от растения => тук се чупи
                    double rarity = double.Parse(cmdData[1]);

                    if (currPlant == null) // ако няма такова растения врищам ерор
                    {
                        Console.WriteLine("error");
                    }
                    else // проверявам дали има такъв обект в колекцията от растения => тук се чупи
                    {
                        currPlant.Rarity = rarity;
                    }
                }
                else if (commandType == "Reset")
                {
                    Plant currPlant = plants.FirstOrDefault(p => p.Name == plantName);// проверявам дали има такъв обект в колекцията от растения => тук се чупи

                    if (currPlant == null)// ако няма такова растения врищам ерор
                    {
                        Console.WriteLine("error");
                    }
                    else
                    {
                        currPlant.Ratings.Clear(); // ако има такова растение трия всички реитинги
                    }
                }
            }

            Console.WriteLine("Plants for the exhibition:"); // принт

            foreach (var plant in plants)
            {
                Console.WriteLine($"- {plant.Name}; Rarity: {plant.Rarity}; Rating: {plant.Ratings.Sum():f2}"); // принт
            }
        }

        public class Plant // клас
        {
            public Plant(string name, double rarity)
            {
                Name = name;
                Rarity = rarity;
                Ratings = new List<double>();
            }

            public string Name { get; set; }
            public double Rarity { get; set; }
            public List<double> Ratings { get; }

            public void AddRating(double rating) // метод в класа за добавяне на рейтинг
            {
                Ratings.Add(rating);
            }
        }
    }
}