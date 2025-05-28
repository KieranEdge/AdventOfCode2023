using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7.CardProcessing
{
    public class HandFinder
    {
        private bool _fiveOfAKind;
        private bool _fourOfAKind;
        private bool _fullHouse;
        private bool _threeOfAKind;
        private bool _twoPair;
        private bool _onePair;
        private bool _highCard;

        public string BestHand(string cardHand)
        {
            HandTypeIdentifier(cardHand);

            if (_fiveOfAKind)
            {
                return "Five of a kind";
            }
            else if (_fourOfAKind)
            {
                return "Four of a kind";
            }
            else if (_fullHouse)
            {
                return "Full House";
            }
            else if (_threeOfAKind)
            {
                return "Three of a kind";
            }
            else if (_twoPair)
            {
                return "Two Pair";
            }
            else if (_onePair)
            {
                return "One Pair";
            }
            else
            {
                return "High Card";
            }
        }

        private void HandTypeIdentifier(string cardHand)
        {
            // First see if there's a five of a kind
            FiveOfAKind(cardHand);
            FourOfAKind(cardHand);
            FullHouse(cardHand);
            ThreeOfAKind(cardHand);
            TwoPair(cardHand);
            OnePair(cardHand);
            HighCard(cardHand);
        }

        private void FiveOfAKind(string cardHand)
        {
            _fiveOfAKind = cardHand.All(c => c == cardHand[0]);
        }   
        
        private void FourOfAKind(string cardHand)
        {
            _fourOfAKind = cardHand.GroupBy(c => c).Any(g => g.Count() == 4);
        }

        private void FullHouse(string cardHand)
        {
            var groups = cardHand.GroupBy(c => c)
                          .Select(g => g.Count())
                          .OrderByDescending(count => count)
                          .ToArray();

            _fullHouse = groups.Length == 2 && groups[0] == 3 && groups[1] == 2;
        }
        private void ThreeOfAKind(string cardHand)
        {
            _threeOfAKind = cardHand.GroupBy(c => c).Any(g => g.Count() == 3);
        }
    
        private void TwoPair (string cardHand)
        {
            var pairCount = cardHand.GroupBy(c => c)
                     .Count(g => g.Count() == 2);

            _twoPair = pairCount == 2;
        }

        private void OnePair(string cardHand)
        {
            var pairCount = cardHand.GroupBy(c => c)
                     .Count(g => g.Count() == 2);

            _onePair = pairCount == 1;
        }

        private void HighCard(string cardHand)
        {
            _highCard = cardHand.Distinct().Count() == cardHand.Length;
        }
    }
}
