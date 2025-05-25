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
        private string _referenceNumbersString;
        private string _winningNumbersString;
        public DataProcessor(string dataToProcess)
        {
            _dataToProcess = dataToProcess;
            StringSplitter();
        }

        private void StringSplitter()
        {
            // Expecting strings in the form of
            //Card   1: 30 48 49 69  1 86 94 68 12 85 | 86 57 89  8 81 85 82 68  1 22 90  2 74 12 30 45 69 92 62  4 94 48 47 64 49
            string combinedNumbersString = _dataToProcess.Split(':')[1];
            _referenceNumbersString = combinedNumbersString.Split('|')[0];
            _winningNumbersString = combinedNumbersString.Split('|')[1];
            Console.WriteLine(_referenceNumbersString);
            Console.WriteLine(_winningNumbersString);
        }
    }
}
