using System.Text;

namespace _01._Activation_Keys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string encryptKey = Console.ReadLine();
            StringBuilder activKey = new StringBuilder(encryptKey);

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Generate")
            {
                string[] command = input.Split(">>>").ToArray();

                switch (command[0])
                {
                    case "Contains":
                        string subStr = command[1];
                        Contains(activKey, subStr);
                        break;
                    case "Flip":
                        string isCase = command[1];
                        int startInd = int.Parse(command[2]);
                        int endInd = int.Parse(command[3]);
                        Flip(activKey, isCase, startInd, endInd);
                        break;
                    case "Slice":
                        int startIndex = int.Parse(command[1]);
                        int endIndex = int.Parse(command[2]);
                        Slice(activKey, startIndex, endIndex);
                        break;
                }
            }

            Console.WriteLine($"Your activation key is: {activKey}");
        }

        private static void Contains(StringBuilder activKey, string subStr)
        {
            if (activKey.ToString().Contains(subStr))
            {
                Console.WriteLine($"{activKey.ToString()} contains {subStr}");
            }
            else
            {
                Console.WriteLine("Substring not found!");
            }
        }

        private static void Flip(StringBuilder activKey, string isCase, int startInd, int endInd)
        {
            string curr = activKey.ToString().Substring(startInd, endInd - startInd);
            string newStr = string.Empty;

            if (isCase == "Upper")
            {
                newStr = curr.ToUpper();
                activKey = activKey.Replace(curr, newStr, startInd, endInd - startInd);
            }
            else if (isCase == "Lower")
            {
                newStr = curr.ToLower();
                activKey = activKey.Replace(curr, newStr, startInd, endInd - startInd);
            }
            Console.WriteLine(activKey.ToString());
        }

        private static void Slice(StringBuilder activKey, int startIndex, int endIndex)
        {
            activKey.Remove(startIndex, endIndex - startIndex);
            Console.WriteLine(activKey.ToString());
        }
    }
}