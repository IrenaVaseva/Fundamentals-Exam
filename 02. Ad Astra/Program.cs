using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace _02._Ad_Astra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"(\||\#)(?<food>[A-Za-z\s*]+)\1(?<expDate>[0-9]{2}\/[0-9]{2}\/[0-9]{2})\1(?<cal>[0-9]+)\1";
            List<Food> listFood = new List<Food>();

            int totalCalories = 0;
            int caloriesPerDay = 2000;

            foreach (Match m in Regex.Matches(input, pattern, RegexOptions.Multiline))
            {
                string food = m.Groups["food"].Value;
                string dateExp = m.Groups["expDate"].Value;
                int calories = int.Parse(m.Groups["cal"].Value);

                Food newFood = new Food(food, dateExp, calories);
                listFood.Add(newFood);

                totalCalories += calories;
            }

            int perDay = totalCalories / caloriesPerDay;
            Console.WriteLine($"You have food to last you for: {perDay} days!");

            foreach (Food food in listFood)
            {
                Console.WriteLine($"Item: {food.Name}, Best before: {food.Date}, Nutrition: {food.Calories}");
            }
        }
    }

    public class Food
    {
        public Food(string name, string date, int calories)
        {
            Name = name;
            Date = date;
            Calories = calories;
        }

        public string Name { get; set; }
        public string Date { get; set; }
        public int Calories { get; set; }
    }
}