using Day8.DataAccess;

// Specifying the file path
string positionFilePath = "C:\\Users\\Kieran Edge\\source\\repos\\AdventOfCode2023\\Day8\\day8_position_data.txt";
string sequenceFilePath = "C:\\Users\\Kieran Edge\\source\\repos\\AdventOfCode2023\\Day8\\day8_sequence_data.txt";

// Reading the two data files and obtaining a dictionary of positions and an array of sequence characters
DataAccess dataAccess = new DataAccess(positionFilePath, sequenceFilePath);
Dictionary<string, (string, string)> positionDirectionDict = dataAccess.positionAndDirections;
char[] sequenceCharacters = dataAccess.sequenceCharacters;

// Initialising the factors needed for the search
bool foundZZZ = false;
int numberOfSteps = 0;
int sequenceIndex = 0;
string position = "AAA";
Console.WriteLine($"Starting Position: {position}");

while (!foundZZZ)
{
    /*
     *  Need to get the next position in the sequence using the index
     *  Need to get next position using the sequence character
     *  increment the sequence index then increment then also check if it's out of range and reset it if so
     *  check if the next position equals ZZZ
     */
  
    char lOrRStep = sequenceCharacters[sequenceIndex];
    if (lOrRStep == 'L')
    {
        position = positionDirectionDict[position].Item1;
    }
    else
    {
        position = positionDirectionDict[position].Item2;
    }

    // Logical check to see if the ZZZ position is found
    foundZZZ = position == "ZZZ";

    // Increment sequence and reseting to zero if at the end
    sequenceIndex++;
    if (sequenceIndex >= sequenceCharacters.Length)
    {
        sequenceIndex = 0;
    }

    numberOfSteps++;
    Console.WriteLine($"Taken {numberOfSteps} steps and moving to {position}, in {lOrRStep} direction");
}