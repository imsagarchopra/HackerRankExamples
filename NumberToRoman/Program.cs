using System;
using System.Collections.Generic;

class NumberToRoman
{
    private static readonly Dictionary<int, string> RomanNumerals = new Dictionary<int, string>
    {
        { 1000, "M" },
        { 900, "CM" },
        { 500, "D" },
        { 400, "CD" },
        { 100, "C" },
        { 90, "XC" },
        { 50, "L" },
        { 40, "XL" },
        { 10, "X" },
        { 9, "IX" },
        { 5, "V" },
        { 4, "IV" },
        { 1, "I" }
    };

    public static string ConvertToRoman(int num)
    {
        if (num <= 0 || num >= 4000)
            throw new ArgumentOutOfRangeException("Input out of range for Roman numerals.");

        string romanNumeral = "";
        foreach (var kvp in RomanNumerals)
        {
            while (num >= kvp.Key)
            {
                romanNumeral += kvp.Value;
                num -= kvp.Key;
            }
        }

        return romanNumeral;
    }

    static void Main(string[] args)
    {
        string isContinue = "";
        do
        {
            Console.Write("Enter a number: ");
            int num = int.Parse(Console.ReadLine());

            try
            {
                string romanNumeral = ConvertToRoman(num);
                Console.WriteLine($"Roman numeral equivalent: {romanNumeral}");
                Console.WriteLine("Do you want to continue (Y/N)?");
                isContinue = Console.ReadLine();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        } while (isContinue.ToLower() == "y");

    }
}
