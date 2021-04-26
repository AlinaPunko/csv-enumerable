using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace CsvEnumerable
{
    public class CsvEnumerable<T> : IEnumerable<T> where T : new()
    {
        private readonly List<T> csvList = new List<T>();

        public CsvEnumerable(StreamReader reader)
        {
            string[] fieldNames = reader.ReadLine()?.Split(",");

            if (fieldNames == null)
            {
                return;
            }

            while (!reader.EndOfStream)
            {
                string[] line = reader.ReadLine()?.Split(",");

                if (line == null)
                {
                    continue;
                }

                var record = (T)Activator.CreateInstance(typeof(T));

                for (var i = 0; i < line.Length; i++)
                {
                    var propertyInfo = record.GetType().GetProperty(fieldNames[i]);
                    
                    if (propertyInfo != null && !string.IsNullOrEmpty(line[i]))
                    {
                        propertyInfo.SetValue(record, Convert.ChangeType(line[i], propertyInfo.PropertyType));
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