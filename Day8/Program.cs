using Day8.DataAccess;
using Day8.Navigation;

public class Program
{
    public static void Main()
    {
        string positionFilePath = "C:\\Users\\Kieran Edge\\source\\repos\\AdventOfCode2023\\Day8\\day8_position_data.txt";
        string sequenceFilePath = "C:\\Users\\Kieran Edge\\source\\repos\\AdventOfCode2023\\Day8\\day8_sequence_data.txt";

        DataAccess dataAccess = new DataAccess(positionFilePath, sequenceFilePath);
        string[] allPositionsToProcess = dataAccess.positionsThatEndInA;

        foreach (string position in allPositionsToProcess)
        {
            Console.WriteLine(position);
        }
        var navigator = new Part2_Navigator(dataAccess.positionAndDirections, dataAccess.sequenceCharacters, dataAccess.positionsThatEndInA);
        int steps = navigator.TraverseUntilAllPositionsEndInZ();
        //int steps = navigator.TraverseUntil("ZZZ");
        Console.WriteLine($"\nTraversal completed in {steps} steps.");
    }
}
