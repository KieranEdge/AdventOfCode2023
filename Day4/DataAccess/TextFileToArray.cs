using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4.DataAccess
{
    public class TextFileToArray
    {
        public string[] Data;
        private string _filePath;

        public TextFileToArray(string filePath)
        {
            _filePath = filePath;
            Data = ProcessTextToArray();
        }

        private string[] ProcessTextToArray()
        {
            Console.WriteLine("Instance Created, parsing data to array");
            try
            {
                List<string> strings = new List<string>(File.ReadAllLines(_filePath));
                return strings.ToArray();
            }
            catch (Exception ex) 
            { 
                Console.WriteLine($"Error reading file: {ex.Message}"); 
                return Array.Empty<string>();
            }
        }
    }
}
