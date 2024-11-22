using System.IO;
using System.Text.RegularExpressions;

String line;
int count = 1;
List<int> gameIds = new List<int>();
String roundsString;
Boolean gamePossible;
Console.WriteLine("Beginning Program!");
List<int> powerList = new List<int>();

try
{
    // Opening the stream reader
    StreamReader sr = new StreamReader("C:\\Users\\Kieran Edge\\source\\repos\\AdventOfCode2023\\Day2\\day2_data.txt");

    // Reading the first line
    line = sr.ReadLine();

    // While loop to iterate whilst the value is not null
    while (line != null)
    {
        Console.WriteLine(line);
        roundsString = await RoundReturner(line);

        powerList.Add(await QuantityWorker(await GameBreaker(roundsString)));

        line = sr.ReadLine();
        count++;
    }
    sr.Close();
    Console.WriteLine($"Sum of Powers: {powerList.AsQueryable().Sum()}");
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}

// Removes the Game part from the raw string
static async Task<string> RoundReturner (string s)
{
    String[] gameSplit = s.Split(':');
 
    return gameSplit[1];
}

// Return an array of rounds
static async Task<string[]> GameBreaker (string s)
{
    String[] roundSplit = s.Split(";");
    return roundSplit;
}

static async Task<int> QuantityWorker(string[] s)
{
    // Lists of the quantities of each colour recorded
    List<int> greenQuantity = new List<int>();
    List<int> redQuantity = new List<int>();
    List<int> blueQuantity = new List<int>();

    // value of the minimum number of colours possible to complete the round
    int minGreen = 1;
    int minRed = 1;
    int minBlue = 1;

    // Iterating over the round to get the quantities of each colour
    foreach (string game in s)
    {
        string[] colourQuantities = game.Split(',');

        foreach (string colour in colourQuantities)
        {
            if (colour.Contains("green"))
            {
                greenQuantity.Add(Int32.Parse(Regex.Match(colour, @"\d+").Value));
            }
            else if (colour.Contains("red"))
            {
                redQuantity.Add(Int32.Parse(Regex.Match(colour, @"\d+").Value));
            }
            else if (colour.Contains("blue"))
            {
                blueQuantity.Add(Int32.Parse(Regex.Match(colour, @"\d+").Value));
            }
        }
    }

    // Getting the max value of each value
    minGreen = greenQuantity.Max();
    minRed = redQuantity.Max();
    minBlue = blueQuantity.Max();

    int minPower = minBlue * minGreen * minRed;
    return minPower;

}
// Need to break up the string into games
// Need to identify the strings based on colours
// Index the games