using System.Text;

namespace _01._Secret_Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder message = new StringBuilder(Console.ReadLine());

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Reveal")
            {
                string[] command = input.Split(":|:", StringSplitOptions.RemoveEmptyEntries).ToArray();

                switch (command[0])
                {
                    case "InsertSpace":
                        int index = int.Parse(command[1]);
                        InsertSpace(message, index);
                        break;
                    case "Reverse":
                        string subStr = command[1];
                        ReverseStr(message, subStr);
                        break;
                    case "ChangeAll":
                        string forReplace = command[1];
                        string replacement = command[2];
                        ChangeAll(message, forReplace, replacement);
                        break;
                }
            }

            Console.WriteLine($"You have a new text message: {message}");
        }

        private static void ChangeAll(StringBuilder message, string forReplace, string replacement)
        {
            message = message.Replace(forReplace, replacement);
            Console.WriteLine(message.ToString());
        }

        private static void ReverseStr(StringBuilder message, string subStr)
        {
            if (message.ToString().Contains(subStr))
            {
                int index = message.ToString().IndexOf(subStr);
                string newStr = new string(subStr.ToCharArray().Reverse().ToArray());
                message.Remove(index, subStr.Length);
                message.Append(newStr);
                Console.WriteLine(message.ToString());
            }
            else
            {
                Console.WriteLine("error");
            }
        }

        private static void InsertSpace(StringBuilder message, int index)
        {
            message = message.Insert(index, " ");
            Console.WriteLine(message.ToString());
        }
    }
}