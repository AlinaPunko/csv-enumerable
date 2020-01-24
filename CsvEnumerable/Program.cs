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
                try
                {
                    CsvEnumerable<CsvRecord> records = new CsvEnumerable<CsvRecord>(reader);

                    foreach (var record in records)
                    {
                        Console.WriteLine(record);
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
