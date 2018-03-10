using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace DictionayTest
{
    class Program
    {

        public static ClassifiedDataItem Classify(DataSet<ClassifiedDataItem> dataset, DataItem input)
        {
            var classes = dataset.Select(d => d.Class).Distinct().ToList();
            int noOfClasses = classes.Count();
            int noOfAttirbutes=input.Attributes.Count();
            double[,] probabilityMatrix=new double[noOfClasses, noOfAttirbutes];

            //Calculating Probability of the input given
            for(int i=0; i<noOfClasses; i++ )
            {
                for(int j=0; j<noOfAttirbutes; j++)
                {
                    var currentAttribute = input.Attributes[j];
                    var currentClass = classes[i];

                    var conditionalProbability = dataset.Where(d => d.Attributes[j] == currentAttribute)
                                    .Where(d => d.Class == currentClass)
                                    .Count();

                    var totalProbability = dataset
                                    .Where(d => d.Class == currentClass)
                                    .Count();
                    Console.WriteLine($"Current Attr - {currentAttribute}");
                    Console.WriteLine($"Current Class - {currentClass}");
                    Console.WriteLine($"Conditional: {conditionalProbability}");
                    Console.WriteLine($"Total: {totalProbability}");

                    probabilityMatrix[i,j] = (double)conditionalProbability / (double)totalProbability;
                }
            }
            

            for(int i=0; i<noOfClasses; i++ )
            {
                for(int j=0; j<noOfAttirbutes; j++)
                {
            
                 Console.Write(probabilityMatrix[i, j]+" ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();

            double[] products = new double[noOfClasses];
            for(int i = 0; i < products.Length; i ++)
            {
                Console.WriteLine($"Multiplying for class {classes[i]}:");
                products[i] = 1;
                for(int j = 0; j < noOfAttirbutes; j++)
                {
                    products[i] *= probabilityMatrix[i,j];
                    Console.Write($"{probabilityMatrix[i,j]}, ");            
                }
                Console.WriteLine();
            }



            Console.WriteLine();
            Console.WriteLine("Products");
            foreach(var p in products)
                Console.Write($"{p} ");

            var maxIndex = 0;
            for(int i=0; i<products.Length; i++)
            {
                if(products[i]>products[maxIndex])
                    maxIndex=i;
            }
            Console.WriteLine($"maxIndex: {maxIndex}");
            Console.WriteLine($"Input belongs to {classes[maxIndex]} class");

            return new ClassifiedDataItem(_class: 0, item: input);
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
            DataItem input = new DataItem(1, 1, 1, 2);
            Classify(dataset, input);
        }
    }
}
