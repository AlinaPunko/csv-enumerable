using System;

namespace CsvEnumerable
{
    public class CsvRecord
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CsvRecord(string[] fields)
        {
            Id = Convert.ToInt32(fields[0]);
            Name = fields[1];
        }

        public CsvRecord() { }

        public override string ToString() => $"{Id} {Name}";
    }
}