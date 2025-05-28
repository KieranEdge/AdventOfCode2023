using Day_6.Data;
using Day_6.Processor;

// Extracting the data to arrays
string filePath = "C:\\Users\\Kieran Edge\\source\\repos\\AdventOfCode2023\\Day 6\\Day6_Data.txt";
int runningTotal = 1;

// PART 1
//IndividualRaces dataAccessor = new IndividualRaces(filePath);
//int[] timeInts = dataAccessor.timeInts;
//int[] distInts = dataAccessor.distanceInts;
//int numberOfRaces = timeInts.Length;
//List<int> possibleVictories = new List<int>();
//for (int i = 0; i < numberOfRaces; i++)
//{
//    possibleVictories.Add(RaceAnalysis.VelocityIterator(timeInts[i], distInts[i]));
//}

//foreach (int victory in possibleVictories)
//{
//    runningTotal = runningTotal * victory;
//}

// Part 2
CombinedRace combinedRace = new CombinedRace(filePath);
long timeInt = combinedRace.timeInt;
long distInt = combinedRace.distanceInt;

long possibleVictories = RaceAnalysis.VelocityIterator(timeInt, distInt);

Console.WriteLine($"Total value of races: {possibleVictories}");