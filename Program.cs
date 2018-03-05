using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace DictionayTest
{
    class Program
    {

        public static ClassifiedDataItem Classify(DataSet<ClassifiedDataItem> dataset, DataItem item)
        {
            var classes = dataset.Select(d => d.Class).Distinct();
            foreach (var c in classes)
            {
                Console.WriteLine(c);
            }
            // Dictionary<int, int>[] d = new Dictionary<int, int>[input.Length+1];
            // for(int i=0; i<d.Length; i++)
            // {
            //     d[i]=new Dictionary<int, int>();
            // }

            // for(int i=0; i<data.Length; i++)
            // {
            //     for(int j=0; j<data[i].Length; j++)
            //     {
            //         // value at first column of current row
            //         int dataValue = data[i][j];

            //         // Increment the value in the dictionary
            //         if(d[j].ContainsKey(dataValue)) //checks if the value exists in the dictionay
            //         {
            //         d[j][dataValue]++;
            //         }
            //         else 
            //         {
            //         d[j][dataValue] = 1;
            //         }

            //     // Print
            //     Console.WriteLine($"Data Value: {dataValue}");
            //     Console.WriteLine($"Count: {d[j][dataValue]}");   
            //     Console.WriteLine();
            //     }
            // }

            return new ClassifiedDataItem(_class: 0, item: item);
        }

        static void Main(string[] args)
        {
            var dataset = new DataSet<ClassifiedDataItem>
                {
                    new ClassifiedDataItem(2,1,1,1,2),
                    new ClassifiedDataItem(2,1,1,1,1),
                    new ClassifiedDataItem(1,2,1,1,2),
                    new ClassifiedDataItem(1,3,2,1,2),
                    new ClassifiedDataItem(1,3,3,2,2),
                    new ClassifiedDataItem(2,3,3,2,1),
                    new ClassifiedDataItem(1,2,3,2,1),
                    new ClassifiedDataItem(2,1,2,1,2),
                    new ClassifiedDataItem(1,1,3,2,2),
                    new ClassifiedDataItem(1,3,2,2,2),
                    new ClassifiedDataItem(1,1,2,2,1),
                    new ClassifiedDataItem(1,2,2,1,1),
                    new ClassifiedDataItem(1,2,1,2,2),
                    new ClassifiedDataItem(2,3,2,1,1)
                };
            DataItem input = new DataItem(1, 2, 2, 2);
            Classify(dataset, input);
        }
    }
}
