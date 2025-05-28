using Day_6.Data;
using Day_6.Processor;

// Extracting the data to arrays
string filePath = "C:\\Users\\Kieran Edge\\source\\repos\\AdventOfCode2023\\Day 6\\Day6_Data.txt";
DataAccessor dataAccessor = new DataAccessor(filePath);
int[] timeInts = dataAccessor.timeInts;
int[] distInts = dataAccessor.distanceInts;
int numberOfRaces = timeInts.Length;
List<int> possibleVictories = new List<int>();
int runningTotal = 1;

for (int i = 0; i < numberOfRaces; i++)
{
    possibleVictories.Add(RaceAnalysis.VelocityIterator(timeInts[i], distInts[i]));
}

foreach (int victory in possibleVictories)
{
    runningTotal = runningTotal * victory;
}

Console.WriteLine($"Total value of races: {runningTotal}");