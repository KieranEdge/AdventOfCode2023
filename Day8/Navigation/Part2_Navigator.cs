using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8.Navigation
{
    public class Part2_Navigator
    {
        private readonly Dictionary<string, (string Left, string Right)> _map;
        private readonly char[] _sequence;
        private int _sequenceIndex = 0;
        private string _currentPosition;
        private string[] _positionsThatEndWithA;
        private int _numberOfPositionsThatEndWithA;
        private bool _stopTraversing = false;

        public Part2_Navigator(Dictionary<string, (string, string)> map, char[] sequence, string[] positionsThatEndWithA)
        {
            _map = map;
            _sequence = sequence;
            _positionsThatEndWithA = positionsThatEndWithA;
            _numberOfPositionsThatEndWithA = _positionsThatEndWithA.Length;
        }

        public int[] TraverseUntilAllPositionsEndInZ()
        {
            // Using LCM Approach
            int[] stepsForEach = new int[_numberOfPositionsThatEndWithA];
            Console.WriteLine($"There are {_numberOfPositionsThatEndWithA}, that end with A");
            int index = 0;

            foreach (string position in _positionsThatEndWithA) 
            {
                // Initialising the search index and position
                Console.WriteLine($"Processing Map {index + 1}, starting at {position}");
                _sequenceIndex = 0;
                _currentPosition = position;
                int steps = 0;

                while (!_currentPosition.EndsWith('Z'))
                {
                    Step(_currentPosition);
                    steps++;
                }
                stepsForEach[index] = steps;
                index++;
            }
            return stepsForEach;
        }

        private void Step(string position)
        {
            // Getting the direction
            char direction = _sequence[_sequenceIndex];
            
            // Getting the next position
            _currentPosition = direction == 'L'
                ? _map[position].Left
                : _map[position].Right;

            _sequenceIndex = (_sequenceIndex + 1) % _sequence.Length;
            // Console.WriteLine($"Step {_sequenceIndex + 1}: Map {index}, Moving to {_currentPosition} in '{direction}' direction");
        }

        private void DoAllPositionsEndInZ()
        {
            List<bool> result = new List<bool>();
            for(int i=0; i < _numberOfPositionsThatEndWithA; i++)
            {
                // for all values at the current position checking if they end with Z
                result.Add(_positionsThatEndWithA[i].EndsWith("Z"));
                Console.WriteLine(_positionsThatEndWithA[i]);
                Console.WriteLine(result[i]);
            }

            // Updating the boolean based on the outcome
            _stopTraversing = result.All(b => b);
        }
    }
}
