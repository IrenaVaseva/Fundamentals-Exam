using System.Text;
using System.Text.RegularExpressions;

namespace _02._Fancy_Barcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patternBarcode = @"(\@\#+)(?<code>[A-Z][A-Za-z0-9]{4,}[A-Z])(\@\#+)";
            string patternDigit = @"(?<digit>[0-9])";
            string input = string.Empty;

            int countBarcode = int.Parse(Console.ReadLine());

            for (int i = 0; i < countBarcode; i++)
            {
                input = Console.ReadLine();
                MatchCollection barcodes = new Regex(patternBarcode).Matches(input);

                if (barcodes.Count > 0)
                {
                    StringBuilder productGroup = new StringBuilder();
                    foreach (Match barcode in barcodes)
                    {
                        string barCode = barcode.Groups["code"].Value;

                        foreach (Match num in Regex.Matches(barCode, patternDigit))
                        {
                            productGroup.Append(num.Groups["digit"].Value.ToString());
                        }
                    }
                    if (productGroup.Length == 0)
                    {
                        Console.WriteLine($"Product group: 00");
                    }
                    else
                    { 
                        Console.WriteLine($"Product group: {productGroup.ToString()}");
                    }
                    
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }

            }

        }
    }
}