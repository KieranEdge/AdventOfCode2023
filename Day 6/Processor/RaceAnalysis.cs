using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_6.Processor
{
    public static class RaceAnalysis
    {
        public static int VelocityIterator(int time, int distance)
        {
            int possibleRaceWins = 0;
            for (int i = 0; i < time; i++)
            {
                // Calculating the charge time versus distance travelled
                int chargeTime = i;
                int remainingTime = time - i;
                int distanceTravelled = chargeTime * remainingTime;
                
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
