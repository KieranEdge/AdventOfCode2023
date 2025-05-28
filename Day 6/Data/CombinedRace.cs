using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_6.Data
{
    public class CombinedRace
    {
        private string _filePath;
        public long timeInt;
        public long distanceInt;
        private string[] _timeAndDistanceText;

        public CombinedRace(string filePath)
        {
            _filePath = filePath;
            _timeAndDistanceText = File.ReadAllLines(_filePath);
            timeInt = ExtractDigits(_timeAndDistanceText[0]);
            distanceInt = ExtractDigits(_timeAndDistanceText[1]);
        }

        private long ExtractDigits(string fileLine)
        {
            // Splits a string, removes the whitespace and converts to int
            string intSubstring = fileLine.Split(':')[1];
            string intSubstringWithoutWhitespace = Regex.Replace(intSubstring, @"\s+", "");
            long processedInt = long.Parse(intSubstringWithoutWhitespace);

            return processedInt;
        }
    }
}