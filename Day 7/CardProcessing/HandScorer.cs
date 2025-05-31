using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day_7.CardProcessing;

namespace Day_7.CardProcessing
{
    public class HandScorer
    {
        private HandFinder handFinder;
        private Dictionary<Char, int> _individualCardValues = new Dictionary<char, int>
        {
            {'A', 13 },
            {'K', 12 },
            {'Q', 11 },
            {'J', 10 },
            {'T', 9 },
            {'9', 8 },
            {'8', 7 },
            {'7', 6 },
            {'6', 5 },
            {'5', 4 },
            {'4', 3 },
            {'3', 2 },
            {'2', 1 },
            {'1', 0 },
        };

        private Dictionary<string, int> _handTypeValues = new Dictionary<string, int>
        {
            {"Five of a kind", 7 },
            {"Four of a kind", 6 },
            {"Full House", 5 },
            {"Three of a kind", 4 },
            {"Two Pair", 3 },
            {"One Pair", 2 },
            {"High Card", 1 }
        };

        public bool CardValueComparison(string handToCompare, string referenceHand)
        {
            string handToCompareType = handFinder.BestHand(handToCompare);
            string referenceHandType = handFinder.BestHand(referenceHand);

            if (_handTypeValues[handToCompareType] > _handTypeValues[referenceHandType])
            {
                return true;
            }
            else
            {
                for (int i = 0; i < handToCompare.Length; i++)
                {
                    char cardToCompare = handToCompare[i];
                    char cardToReference = referenceHand[i];

                    if (_individualCardValues[cardToCompare] > _individualCardValues[cardToReference])
                    {
                        return true;
                    }
                }
            }
            return false;

        }
    } 
}
