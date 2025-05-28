using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4.DataProcessing
{
    public class DataProcessor
    {
        private int[]? _referenceNumbersInts;
        private int[]? _winningNumbersInts;
        private int _winningNumbers = 0;
        private int _totalPoints = 0;
        private List<int>? _indicesOfCards = new List<int>();
        private string[] _cardsToProcess;
        private bool _finished = false;

        public DataProcessor(string[] cardsToProcess)
        {
            _cardsToProcess = cardsToProcess;
            for (int i = 0; i < _cardsToProcess.Length; i++)
            {
                _indicesOfCards.Add(i);
            }
        }

        public void ProcessorOfCard()
        {
            foreach(int i in _indicesOfCards)
            {
                Console.WriteLine(i);
            }
        }

        public void Process(string FileLineToProcess)
        {
            _winningNumbers = 0;
            StringSplitter(FileLineToProcess);
            ProcessReferenceNumbers();
            PointsTotal();
        } 

        private void StringSplitter(string FileLineToProcess)
        {
            // Function for getting an array of winning numbers and reference numbers
            string combinedNumbersString = FileLineToProcess.Split(':')[1];

            _referenceNumbersInts = StringOfNumbersIntoArray(combinedNumbersString.Split('|')[0]);
            _winningNumbersInts = StringOfNumbersIntoArray(combinedNumbersString.Split('|')[1]);
        }

        public int ReturnTotalScore()
        {
            // Return function for the total score
            return _totalPoints;
        }

        private int[] StringOfNumbersIntoArray(string NumbersStringToSplit)
        {
            // Function for splitting the numbers from the substrings into an array
            string[] numbers = NumbersStringToSplit.Split(null);
            List<int> numbersList = new List<int>();

            foreach (string number in numbers)
            {
               if (number != "")
               {
                    numbersList.Add(int.Parse(number));
               }
            }
            return numbersList.ToArray();
        }

        private void ReferenceNumberInWinningList(int referenceNumber)
        {
            // Checking if a given number is in the reference list
            if (_winningNumbersInts.Contains(referenceNumber))
            {
                _winningNumbers++;
            }
        }

        private void ProcessReferenceNumbers()
        {
            // Function for iterating over a list of reference numbers
            foreach (int referenceNumber in _referenceNumbersInts)
            {
                ReferenceNumberInWinningList(referenceNumber);
            }
        }

        private void PointsTotal()
        {
            // Function for adding points based on number of identified matches
            Console.WriteLine($"Total number of winning number: {_winningNumbers}");
            _totalPoints = _totalPoints +  (int)Math.Pow(2, _winningNumbers - 1);
            Console.WriteLine($"Giving a total running score of: {_totalPoints}");
        }
    }
}
