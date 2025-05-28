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
        private int _index = 0;
        private int _originalLength;

        public DataProcessor(string[] cardsToProcess)
        {
            _cardsToProcess = cardsToProcess;
            _originalLength = cardsToProcess.Length;
            for (int i = 0; i < _originalLength; i++)
            {
                _indicesOfCards.Add(i);
            }
        }

        public void ProcessorOfCards()
        {
            while (!_finished)
            {
                //Processing the scratchcard at the index as dictated by the index of cards list which is being generated
                _winningNumbers = 0;
                StringSplitter(_cardsToProcess[_indicesOfCards[_index]]);
                ProcessReferenceNumbers();
                IndexAdder(_indicesOfCards[_index]);
                EndOfCards();
                _index++;
                Console.WriteLine($"{_winningNumbers} found, adding cards to the end of the list");
                Console.WriteLine($"{_indicesOfCards.Count} Scratchcards now in pack");
                Console.WriteLine($"{_indicesOfCards.Last()} Is the final index");
                _finished = true;
            }
        }

        private void IndexAdder(int scratchCardNumber)
        {
            // Function for adding the next winning number of scratch cards to the end of the list
            if (_winningNumbers > 0)
            {
                if (scratchCardNumber + _winningNumbers < _originalLength)
                {
                    // Adding the cards if in range
                    for (int i = scratchCardNumber + 1; i <= scratchCardNumber + _winningNumbers; i++)
                    {
                        _indicesOfCards.Add(i);
                    }
                }
                else
                {
                    // Adding the cards to the end of the list
                    for (int i = scratchCardNumber + 1; i < _originalLength; i++)
                    {
                        _indicesOfCards.Add(i);
                    }
                }
                
            }
        }

        private void EndOfCards()
        {
            // Function to check if there are any more cards to add
            if(_index == _indicesOfCards.Count())
            {
                _finished = true;
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
