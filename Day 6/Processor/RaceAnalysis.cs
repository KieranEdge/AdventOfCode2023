using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_6.Processor
{
    public static class RaceAnalysis
    {
        public static long VelocityIterator(long time, long distance)
        {
            int possibleRaceWins = 0;
            for (int i = 0; i < time; i++)
            {
                // Calculating the charge time versus distance travelled
                long chargeTime = i;
                long remainingTime = time - i;
                long distanceTravelled = chargeTime * remainingTime;
                
                if (distanceTravelled > distance)
                {
                    possibleRaceWins++;
                }
            }

            Console.WriteLine($"Number of possible race wins: {possibleRaceWins}");
            return possibleRaceWins;
        }
    }
}
