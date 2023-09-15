using System;
using static System.Formats.Asn1.AsnWriter;

class NumberToWords
{
    private static string[] units = {
        "Zero", "One", "Two", "Three", "Four",
        "Five", "Six", "Seven", "Eight", "Nine"
    };

    private static string[] teens = {
        "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen",
        "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"
    };

    private static string[] tens = {
        "Twenty", "Thirty", "Forty", "Fifty",
        "Sixty", "Seventy", "Eighty", "Ninety"
    };

    private static string[] thousands = { "", "Thousand", "Million", "Billion", "Trillion" };
    //private static string[] thousands = { "", "Thousand", "Lakh", "Crore", "Arab", "Kharab", "Neel", "Padma", "Shankh" };   

    public static string NumberToWordsConverter(decimal num)
    {
        if (num < 0)
        {
            return "Negative " + NumberToWordsConverter(-num);
        }
        else if (num == 0)
        {
            return units[0];
        }
        else
        {
            string words = "";
            long integerPart = (long)Math.Floor(num);
            decimal fractionalPart = num - integerPart;

            if (integerPart > 0)
            {
                words = ConvertIntegerToWords(integerPart);
            }

            if (fractionalPart > 0)
            {
                words += " Point " + ConvertDecimalToWords(fractionalPart);
            }

            return words;
        }
    }

    private static string ConvertIntegerToWords(long num)
    {
        if (num == 0)
        {
            return "";
        }

        string words = "";
        //int scale = 0;

        for (int i = 0; num > 0; i++, num /= 1000)
        {
            if (num % 1000 != 0)
            {
                words = $"{ConvertHundred((int)(num % 1000))} {thousands[i]} {words}";
            }
        }

        //while (num > 0)
        //{
        //    if (num % 1000 != 0)
        //    {              
        //        string chunk = ConvertHundred((int)(num % 1000));
        //        if (!string.IsNullOrEmpty(chunk))
        //        {
        //            if (scale > 0)
        //                chunk += $" {thousands[scale]}";
        //            words = $"{chunk} {words}";
        //        }
        //    }
        //    num /= 1000;
        //    scale++;
        //}

        return words.Trim();
    }

    private static string ConvertDecimalToWords(decimal num)
    {               
        string words = "";

        // Extracting the fractional part of the decimal number
        string fractionalPart = (num - Math.Floor(num)).ToString("F2").Substring(2);

        foreach (char digit in fractionalPart)
        {
            words += units[int.Parse(digit.ToString())] + " ";
        }

        return words.Trim();
    }

    private static string ConvertHundred(int num)
    {
        if (num == 0)
            return "";
        string result = "";
        if (num >= 100)
        {
            result = $"{units[num / 100]} Hundred";
            num %= 100;
            if (num > 0)
                result += " and ";
        }
        if (num >= 20)
        {
            result += $"{tens[(num / 10) - 2]}";
            if (num % 10 != 0)
                result += $"-{units[num % 10]}";
        }
        else if (num >= 10)
        {
            result += teens[num - 10];
        }
        else if (num > 0)
        {
            result += units[num];
        }
        return result;
    }

    static void Main(string[] args)
    {
        string isContinue = "";
        do
        {
            Console.Write("Enter a number: ");
            decimal num = decimal.Parse(Console.ReadLine());

            string result = NumberToWordsConverter(num);
            Console.WriteLine($"English representation: {result}");

            Console.WriteLine("Do you want to continue (Y/N)?");
            isContinue = Console.ReadLine();
        } while (isContinue.ToLower() == "y");
        
    }
}
