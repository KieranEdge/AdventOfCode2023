using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8.Navigation
{
    public class Part1_Navigator
    {
        private readonly Dictionary<string, (string Left, string Right)> _map;
        private readonly char[] _sequence;
        private int _sequenceIndex;
        private string _currentPosition;

        public Part1_Navigator(Dictionary<string, (string, string)> map, char[] sequence)
        {
            _map = map;
            _sequence = sequence;
            _sequenceIndex = 0;
            _currentPosition = "AAA";
        }

        public int TraverseUntil(string target)
        {
            int steps = 0;
            Console.WriteLine($"Starting Position: {_currentPosition}");

            while (_currentPosition != target)
            {
                Step();
                steps++;
            }

            return steps;
        }

        private void Step()
        {
            char direction = _sequence[_sequenceIndex];
            _currentPosition = direction == 'L'
                ? _map[_currentPosition].Left
                : _map[_currentPosition].Right;

            Console.WriteLine($"Step {_sequenceIndex + 1}: Moving to {_currentPosition} in '{direction}' direction");

            _sequenceIndex = (_sequenceIndex + 1) % _sequence.Length;
        }
    }
}