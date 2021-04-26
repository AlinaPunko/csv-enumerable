using System;

namespace CsvEnumerable
{
    public class CsvRecord
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public override string ToString() => $"{Id} {Name}";
    }
}