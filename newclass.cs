using System.Collections;
using System.Collections.Generic;
using System;

namespace DictionayTest
{
    public class DataItem
    {
        public double[] Attributes { get; set; }
        public string Meta { get; set; }

        public DataItem(int numberOfAttributes)
        {
            Attributes = new double[numberOfAttributes];
        }

        public DataItem()
        {
            Attributes = new double[] { };
        }

        public DataItem(params double[] attributes)
        {
            this.Attributes = attributes;
        }

        public static DataItem Average(params DataItem[] dataset)
        {
            _ = dataset ?? throw new ArgumentNullException(nameof(dataset));
            if(dataset.Length == 0)
            {
                throw new ArgumentException("The dataset must have atleast one dataitem.", nameof(dataset));
            }

            var first = dataset[0];
            for(int i = 1; i < dataset.Length; i++)
            {
                if(dataset[i].Attributes.Length != first.Attributes.Length)
                {
                    throw new ArgumentException("Every dataitem must have the same number of attributes.");
                }
            }

            var average = new DataItem(numberOfAttributes: first.Attributes.Length);
            foreach(var dataitem in dataset)
            {
                for(int i = 0; i < average.Attributes.Length; i++)
                {
                    average.Attributes[i] += dataitem.Attributes[i];
                }
            }
            for(int i = 0; i < average.Attributes.Length; i++)
            {
                average.Attributes[i] /= dataset.Length;
            }

            return average;
        }
    }

    public class DataSet<T> : List<T> where T : DataItem
    {

        public DataSet() { }
        public DataSet(IEnumerable<T> collection) : base(collection) { }
        public DataSet(int capacity) : base(capacity) { }

        public DataItem Average()
        {
            return DataItem.Average(this.ToArray());
        }
    }

    public class ClassifiedDataItem : DataItem
    {
        public int Class { get; set; }

        public ClassifiedDataItem() { }
        public ClassifiedDataItem(int numberOfAttributes) 
            : base(numberOfAttributes) { }
        public ClassifiedDataItem(int _class, DataItem item)
            : this(_class, item.Attributes) { }
        public ClassifiedDataItem(int _class, params double[] attributes)
            : base(attributes) 
        {
            Class = _class;
        }
    }

}