using Day4.DataAccess;
using Day4.DataProcessing;
using System.ComponentModel;

Console.WriteLine("Beginning Program!");
int totalScore = 0;

// Processing the file into an array of strings per line
string filePath = "C:\\Users\\Kieran Edge\\source\\repos\\AdventOfCode2023\\Day4\\Day4_data.txt";
TextFileToArray dataAccess = new TextFileToArray(filePath);
string[] textFileLines = dataAccess.Data;

// Processing the data line by line
DataProcessor dataProcessor = new DataProcessor(textFileLines);
dataProcessor.ProcessorOfCards();
