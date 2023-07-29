using System.Drawing;
using System.Text.RegularExpressions;

namespace _02._Emoji_Detector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<emoji>(\:{2}|\*{2})[A-Z][a-z]{2,}\1)";
            string patternDigit = @"(?<num>[0-9])";
            Dictionary<string, int> dicEmojis = new Dictionary<string, int>();

            string input = Console.ReadLine();
            int coolThresholdSum = 1;

            foreach (Match n in Regex.Matches(input, patternDigit, RegexOptions.Multiline))
            {
                coolThresholdSum *= int.Parse(n.Groups["num"].Value);
            }

            foreach (Match m in Regex.Matches(input, pattern, RegexOptions.Multiline))
            {
                string emoji = m.Groups["emoji"].Value;
                //string emojiNew = emoji.Substring(2, emoji.Length - 4);
                string emojiNew = emoji.Replace(":", "").Replace("*", "");
                //emojiNew = emoji.Replace("*", "");

                int coolness = 0;
                for (int i = 0; i < emojiNew.Length; i++)
                {
                    coolness += emojiNew[i];
                }
 
                    dicEmojis.Add(emoji, coolness);
                
            }

            int countEmojis = dicEmojis.Count;
            Console.WriteLine($"Cool threshold: {coolThresholdSum}");
            Console.WriteLine($"{countEmojis} emojis found in the text. The cool ones are:");

            foreach (var e in dicEmojis.Where(e=>e.Value>=coolThresholdSum))
            {
                Console.WriteLine(e.Key);
            }
        }
    }
}