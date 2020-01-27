using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CsvEnumerable
{
    public class CsvEnumerable<T> : IEnumerable<T> where T : new()
    {
        private readonly List<T> csvList = new List<T>();

        public CsvEnumerable(StreamReader reader)
        {
            var header = reader.ReadLine()?.Split(",");

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine()?.Split(",");
                var record = (T)Activator.CreateInstance(typeof(T));

                if (line != null && header != null)
                {
                    for (var i = 0; i < line.Length; i++)
                    {
                        var propertyInfo = record.GetType().GetProperty(header[i]);
                        if (propertyInfo != null)
                        {
                            propertyInfo.SetValue(record, line[i]);
                        }
                    }
                }

                Add(record);
            }
        }

        public void Add(T record)
        {
            csvList.Add(record);
        }

        public void AddRange(T[] records)
        {
            csvList.AddRange(records);
        }

        public IEnumerator GetEnumerator() => csvList.GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => csvList.GetEnumerator();
    }
}