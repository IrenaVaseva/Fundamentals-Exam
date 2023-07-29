using System.Text;

namespace _01._The_Imitation_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string encryptMess = Console.ReadLine();
            StringBuilder decryptMess = new StringBuilder(encryptMess);

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Decode")
            {
                string[] command = input.Split("|").ToArray();

                switch (command[0])
                {
                    case "Move":
                        int count = int.Parse(command[1]);
                        Move(decryptMess, count);
                        break;
                    case "Insert":
                        int index = int.Parse(command[1]);
                        string value = command[2];
                        Insert(decryptMess, index, value);

                        break;
                    case "ChangeAll":
                        string oldValue = command[1];
                        string newValue = command[2];
                        ChangeAll(decryptMess, oldValue, newValue);
                        break;
                }

            }

            Console.WriteLine($"The decrypted message is: {decryptMess.ToString()}");
        }

        private static void ChangeAll(StringBuilder decryptMess, string oldValue, string newValue)
        {
            decryptMess.Replace(oldValue, newValue);
        }

        private static void Insert(StringBuilder decryptMess, int index, string value)
        {
            decryptMess.Insert(index, value);
        }

        private static void Move(StringBuilder decryptMess, int count)
        {
            string curr = decryptMess.ToString().Substring(0, count);
            decryptMess.Remove(0, count);
            decryptMess.Append(curr);
        }
    }
}