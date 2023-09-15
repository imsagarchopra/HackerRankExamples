using System;
using System.Collections.Generic;

class RomanToNumber
{
    private static readonly Dictionary<char, int> RomanNumerals = new Dictionary<char, int>
    {
        { 'I', 1 },
        { 'V', 5 },
        { 'X', 10 },
        { 'L', 50 },
        { 'C', 100 },
        { 'D', 500 },
        { 'M', 1000 }
    };

    public static int ConvertToNumber(string romanNumeral)
    {
        int total = 0;

        for (int i = 0; i < romanNumeral.Length; i++)
        {
            int currentValue = RomanNumerals[romanNumeral[i]];          

            if (i < romanNumeral.Length - 1 && RomanNumerals[romanNumeral[i + 1]] > currentValue)
                total -= currentValue;
            else
                total += currentValue;
        }

        return total;
    }

    static void Main(string[] args)
    {
        string isContinue = "";
        do
        {
            Console.Write("Enter a Roman numeral: ");
            string romanNumeral = Console.ReadLine().ToUpper();

            try
            {
                int decimalNumber = ConvertToNumber(romanNumeral);
                Console.WriteLine($"Decimal number equivalent: {decimalNumber}");
                Console.WriteLine("Do you want to continue (Y/N)?");
                isContinue = Console.ReadLine();
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Invalid Roman numeral.");
            }
        } while (isContinue.ToLower() == "y");
    }
}
