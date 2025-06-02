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

        public int TraverseUntilAllPositionsEndInZ()
        {
            int steps = 0;
            Console.WriteLine($"There are {_numberOfPositionsThatEndWithA}, that end with A");

            while (!_stopTraversing)
            {
                // Iterating over the positions that end with A
                int index = 0;
                foreach (string position in _positionsThatEndWithA)
                {
                    Step(position, index);
                    index++;
                }
                steps++;
                _sequenceIndex = (_sequenceIndex + 1) % _sequence.Length;

                DoAllPositionsEndInZ();
            }

            return steps;
        }

        private void Step(string position, int index)
        {
            // Getting the direction
            char direction = _sequence[_sequenceIndex];
            
            // Getting the next position
            _currentPosition = direction == 'L'
                ? _map[position].Left
                : _map[position].Right;

            // Putting the next position in the index
            _positionsThatEndWithA[index] = _currentPosition;
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
