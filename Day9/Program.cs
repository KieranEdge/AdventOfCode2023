using Day9.DataAccess;
using Day9.SequenceAnalyser;

// Accessing the data as a list of arrays
DataAccessor dataAccessor = new DataAccessor("C:\\Users\\Kieran Edge\\source\\repos\\AdventOfCode2023\\Day9\\Day9_data.txt");
List<int[]> sequenceData = dataAccessor._arrayOfSequences;

// Analysing the sequences
int[] extrapolatedValues = new int[sequenceData.Count];
Console.WriteLine($"There are {sequenceData.Count} sequences to inspect");

int nextValue = SequenceAnalyser.GetNextValueInSequence(sequenceData[0]);

for(int i = 0;  i < sequenceData.Count; i++)
{
    extrapolatedValues[i] = SequenceAnalyser.GetNextValueInSequence(sequenceData[i]);
    Console.WriteLine($"Next value for sequence {i + 1}: {extrapolatedValues[i]}");
}

Console.WriteLine($"Sum of predicted values: {extrapolatedValues.Sum()}");