using System.Text;

namespace _01._Password_Reset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string encryptPass = Console.ReadLine();
            StringBuilder newPass = new StringBuilder(encryptPass);
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Done")
            {
                string[] command = input.Split().ToArray();

                switch (command[0])
                {
                    case "TakeOdd":
                        newPass=TakeOdd(newPass);
                        break;
                    case "Cut":
                        int index = int.Parse(command[1]);
                        int len = int.Parse(command[2]);
                        Cut(newPass, index, len);
                        break;
                    case "Substitute":
                        string oldStr = command[1];
                        string newStr = command[2];
                        Substitute(newPass, oldStr, newStr);
                        break;
                }
            }

            Console.WriteLine($"Your password is: {newPass.ToString()}");
        }

        private static void Substitute(StringBuilder newPass, string oldStr, string newStr)
        {
            if (newPass.ToString().Contains(oldStr))
            {
                newPass.Replace(oldStr, newStr);
                Console.WriteLine(newPass.ToString());
            }
            else
            {
                Console.WriteLine("Nothing to replace!");
            }
        }

        private static void Cut(StringBuilder newPass, int index, int len)
        {
            newPass.Remove(index, len);
            Console.WriteLine(newPass.ToString());
        }

        private static StringBuilder TakeOdd(StringBuilder newPass)
        {
            StringBuilder sb=new StringBuilder();
            for (int i = 1; i < newPass.Length; i += 2)
            {
                sb.Append(newPass[i].ToString());
            }
            Console.WriteLine(sb.ToString());
            return sb;
        }
    }
}