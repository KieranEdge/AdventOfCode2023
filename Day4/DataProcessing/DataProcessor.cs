using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4.DataProcessing
{
    public class DataProcessor
    {
        private string _dataToProcess;
        private int[] _referenceNumbersInts;
        private int[] _winningNumbersInts;
        private int _winningNumbers = 0;
        private int _totalPoints = 0;

        public DataProcessor(string dataToProcess)
        {
            _dataToProcess = dataToProcess;
            StringSplitter();
            ProcessReferenceNumbers();
            PointsTotal();
        }

        private void StringSplitter()
        {
            // Expecting strings in the form of
            //Card   1: 30 48 49 69  1 86 94 68 12 85 | 86 57 89  8 81 85 82 68  1 22 90  2 74 12 30 45 69 92 62  4 94 48 47 64 49
            string combinedNumbersString = _dataToProcess.Split(':')[1];

            _referenceNumbersInts = StringOfNumbersIntoArray(combinedNumbersString.Split('|')[0]);
            _winningNumbersInts = StringOfNumbersIntoArray(combinedNumbersString.Split('|')[1]);
        }

        public int ReturnTotalScore()
        {
            return _totalPoints;
        }

        private int[] StringOfNumbersIntoArray(string NumbersStringToSplit)
        {
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
            if (_winningNumbersInts.Contains(referenceNumber))
            {
                _winningNumbers++;
            }
        }

        private void ProcessReferenceNumbers()
        {
            foreach (int referenceNumber in _referenceNumbersInts)
            {
                ReferenceNumberInWinningList(referenceNumber);
            }
        }

        private void PointsTotal()
        {
            Console.WriteLine($"Total number of winning number: {_winningNumbers}");
            _totalPoints = (int)Math.Pow(2, _winningNumbers - 1);
            Console.WriteLine($"Giving a total score of: {_totalPoints}");
        }
    }
}
