using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day8.DataAccess
{
    public class DataAccess
    {
        public Dictionary<string, (string, string)> positionAndDirections = new Dictionary<string, (string, string)>();
        private string _positionsFilePath;
        private string _sequenceFilePath;
        private string _sequenceString;
        private string[] _allPositionLines;
        public char[] sequenceCharacters;

        
        public DataAccess(string positionsFilePath, string sequenceFilePath)
        {
            _positionsFilePath = positionsFilePath;
            _sequenceFilePath = sequenceFilePath;
            _allPositionLines = File.ReadAllLines(_positionsFilePath);
            _sequenceString = File.ReadAllText(_sequenceFilePath);
            DictionaryConstructor();
            SequenceArrayConstructor();
        }

        private void DictionaryConstructor()
        {
            foreach(string line in _allPositionLines)
            {
                // Breaking down the input string into components
                string position = line.Split(" =")[0];
                string directionsWithBrackets = line.Split('(')[1];
                string directionsWithoutBrackets = directionsWithBrackets.Split(')')[0];
                string leftPosition = directionsWithoutBrackets.Split(", ")[0];
                string rightPosition = directionsWithoutBrackets.Split(", ")[1];

                positionAndDirections.Add(position, (leftPosition, rightPosition));
            }
        }

        private void SequenceArrayConstructor()
        {
            List<char> sequence = new List<char>();
            foreach (char character in _sequenceString)
            {
                sequence.Add(character);
            }
            sequenceCharacters = sequence.ToArray();
        }
    }
}
