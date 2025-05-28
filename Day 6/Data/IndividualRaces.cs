using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/* To Do
 * - Read Text File
 * - Read Line One and Extract Values to Time Array
 * - Read Line Two and Extract Values to Time Array
*/

namespace Day_6.Data
{
    public class IndividualRaces
    {
        private string _filePath;
        public int[] timeInts;
        public int[] distanceInts;
        private string[] _timeAndDistanceText;

        public IndividualRaces(string filePath) 
        {
            _filePath = filePath;
            _timeAndDistanceText = File.ReadAllLines(_filePath);
            timeInts = ExtractDigits(_timeAndDistanceText[0]);
            distanceInts = ExtractDigits(_timeAndDistanceText[1]);
        }

        private int[] ExtractDigits(string fileLine)
        {
            // sample string Time:        46     85     75     82
            int[] numbers = Regex.Matches(fileLine, @"\d+")
                             .Cast<Match>()
                             .Select(m => int.Parse(m.Value))
                             .ToArray();
            
            return numbers;
        }
    }
}
