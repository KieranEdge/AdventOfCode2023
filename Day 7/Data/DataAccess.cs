using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7.Data
{
    public class DataAccess
    {
        private string _filePath;
        public string[] cardHands;
        public int[] gambits;
        public Dictionary<string, int> handsAndGambitsDict;
        private string[] _allLines;

        public DataAccess(string filePath)
        {
            _filePath = filePath;
            _allLines = File.ReadAllLines(_filePath);
            CardHandAccessor();
            GambitAccessor();
            DictionaryPopulator();
            cardHands.
        }

        public void DictionaryPopulator()
        {
            foreach (string line in _allLines)
            {
                string hand = line.Split(' ')[0];
                int gambit = int.Parse(line.Split(' ')[1]);
                handsAndGambitsDict.Add(hand, gambit);
            }
            
        }

        private void CardHandAccessor()
        {

            List<string> lines = new List<string>();
            foreach (string line in _allLines)
            {
                string hand = line.Split(' ')[0];
                lines.Add(hand);
            }
            cardHands = lines.ToArray();
        }

        private void GambitAccessor()
        {
            List<int> lines = new List<int>();
            foreach (string line in _allLines)
            {
                string gambitString = line.Split(' ')[1];
                int gambitInt = int.Parse(gambitString);
                lines.Add(gambitInt);
            }
            gambits = lines.ToArray();
        }
    }
}
