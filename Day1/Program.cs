// See https://aka.ms/new-console-template for more information
using System.IO;
Console.WriteLine("Beginning Program!");

String line;
int initialCount = 0;
String lineReversed;
String lineConverted;
String firstDigit = "0";
String secondDigit= "0";
String combinedNumbers;
List<int> numbers = new List<int>();

try
{
    // Opening the stream reader
    StreamReader sr = new StreamReader("C:\\Users\\Kieran Edge\\source\\repos\\AdventOfCode2023\\Day1\\Day1_data.txt");
    
    // Reading the first line
    line = sr.ReadLine();

    // While loop to iterate whilst the value is not null
    while (line != null)
    {
        // Converting the line to numbers
        lineConverted = await ConvertToNumbers(line);

        // Reversing the line
        lineReversed = await Reverse(lineConverted);

        //Console.WriteLine($"Raw input: {line}");
        //Console.WriteLine($"Converted value: {lineConverted}");
        //Console.WriteLine($"Reversed Line: {lineReversed}");
        

        // Iterate over the string to get the first digit
        foreach (char c in lineConverted)
        {
            // Breaking at the first character that is a numeric digit
            if (Char.IsNumber(c))
            {
                firstDigit = c.ToString();
                break;
            }
        }

        // Iterating over the reversed line
        foreach(char c in lineReversed)
        {
            if (Char.IsNumber(c))
            {
                secondDigit = c.ToString();
                break;
            }
        }

        combinedNumbers = String.Concat(firstDigit, secondDigit);
        //Console.WriteLine($"First Digit:  {firstDigit}");
        //Console.WriteLine($"Second Digit:  {secondDigit}");
        //Console.WriteLine($"Combined Number:  {combinedNumbers}");
        
        numbers.Add(Int32.Parse(combinedNumbers));
        initialCount++;
        line = sr.ReadLine();
    }
    sr.Close();
    Console.WriteLine($"Total Lines Process: {initialCount}");
    Console.WriteLine($"Sum of digits: {numbers.AsQueryable().Sum()}");
}
catch(Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}

// Method used for reversing a string
static async Task<string> Reverse(string s)
{
    char[] charArr = s.ToCharArray();
    Array.Reverse(charArr);
    return new string(charArr);
}

// Method used for converting number words in strings to number characters
static async Task<string> ConvertToNumbers (string s)
{
    // Replacing written numbers with their character equivalent
    String convertedString = s.Replace("one", "1").Replace("two", "2").Replace("three", "3")
        .Replace("four", "4").Replace("five", "5").Replace("six", "6").Replace("seven", "7")
        .Replace("eight", "8").Replace("nine", "9");
    
    return convertedString;
}
Console.WriteLine("Program Complete");