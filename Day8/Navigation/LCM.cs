using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8.Navigation
{
    public class LCM
    {
        private int[] _individualSteps;
        public long lcmOfPaths;

        public LCM(int[] individualSteps)
        {
            _individualSteps = individualSteps;
            lcmOfPaths = FindLCM(_individualSteps); 
        }

        private long FindLCM(int[] numbers)
        {
            return numbers.Aggregate((long)numbers[0], (acc, val) => LCMCalc(acc, val));
        }

        // LCM of two numbers using GCD
        public static long LCMCalc(long a, long b)
        {
            return Math.Abs(a * b) / GCD(a, b);
        }

        // Euclidean algorithm for GCD
        public static long GCD(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}
