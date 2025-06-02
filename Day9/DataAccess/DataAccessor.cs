using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9.DataAccess
{
    public class DataAccessor
    {
        private string _filePath;
        public List<int[]> _arrayOfSequences = new List<int[]>();

        public DataAccessor(string filePath)
        {
            _filePath = filePath;
            _arrayOfSequences = FileDataToArrayOfSequences();
        }

        private List<int[]> FileDataToArrayOfSequences()
        {
            List<int[]> sequences = File.ReadLines(_filePath)
            .Select(line => line
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray())
            .ToList();

            return sequences;
        }


    }
}
