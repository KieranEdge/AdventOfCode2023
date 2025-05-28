using Day_7.Data;
using Day_7.CardProcessing;

// Accessing the data
string filePath = "C:\\Users\\Kieran Edge\\source\\repos\\AdventOfCode2023\\Day 7\\Day7_Data.txt";
DataAccess dataAccess = new DataAccess(filePath);
string[] handArray = dataAccess.cardHands;
int[] gambitsArray = dataAccess.gambits;

// Processing the hands
HandFinder handFinder = new HandFinder();
string handType;

foreach(string hand in handArray)
{
    handType = handFinder.BestHand(hand);
    Console.Write(handType);
    Console.Write(Environment.NewLine);
}