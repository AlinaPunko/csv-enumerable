using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace CsvEnumerable
{
    public class CsvEnumerable<T> : IEnumerable<T> where T : new()
    {
        private readonly List<T> _csvList = new List<T>();

        public CsvEnumerable(StreamReader reader)
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine()?.Split(",");
                T record = (T)Activator.CreateInstance(typeof(T), new object[] { line });
                Add(record);
            }
        }

        public void Add(T record)
        {
            _csvList.Add(record);
        }

        public void AddRange(T[] records)
        {
            _csvList.AddRange(records);
        }

        public IEnumerator GetEnumerator() => _csvList.GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => _csvList.GetEnumerator();
    }
}