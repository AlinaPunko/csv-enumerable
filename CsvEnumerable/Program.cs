using System;
using System.IO;

namespace CsvEnumerable
{
    class Program
    {
        private static void Main()
        {
            using var reader = new StreamReader(@"text.csv");
            {
                var records = new CsvEnumerable<CsvRecord>(reader);

                foreach (var record in records)
                {
                    Console.WriteLine(record);
                }
            }
        }
    }
}
