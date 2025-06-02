using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9.SequenceAnalyser
{
    public static class SequenceAnalyser
    {
        public static int GetNextValueInSequence(int[] sequence)
        {
            // Getting the initial list and initial last value
            List<int> NextSequenceToInspect = sequence.ToList();
            int lastNumberInOriginalSequence = NextSequenceToInspect.Last();
            int valueToAddForPrediction;

            // Going to add the last number of each list to the last number
            List<int> lastNumbers = new List<int>();
            bool allZeros = false;

            while (!allZeros) 
            {
                // Initiating a list of differences
                List<int> listOfDifferences = new List<int>();

                // Creating a list of differences
                for (int i = 0; i < NextSequenceToInspect.Count - 1; i++)
                {
                    listOfDifferences.Add(NextSequenceToInspect[i + 1] - NextSequenceToInspect[i]);
                }

                // Updating the next list to inspect from the difference list above
                NextSequenceToInspect = listOfDifferences;

                // Adding the last number of the differences to the list
                lastNumbers.Add(listOfDifferences.Last());

                // Checking if the list is all zeros
                allZeros = IsArrayZero(listOfDifferences);

            }

            valueToAddForPrediction = CalculateNextValue(lastNumbers);

            return lastNumberInOriginalSequence + valueToAddForPrediction;
            
        }

        private static bool IsArrayZero(List<int> listToInspect)
        {
            // Method to check if all array is 0
            return listToInspect.All(x => x == 0);
        }

        private static int CalculateNextValue(List<int> listToInspect) 
        {
            // Returning the sum of the list
            return listToInspect.Sum(x => x);
        }
    }
}
