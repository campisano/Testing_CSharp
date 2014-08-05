using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace Test_BynarySearch
{
    public class Program
    {
        public static bool basicSearch(double[] a, double key, ref int index)
        {
            for (int i = 0; i < a.Count(); ++i)
            {
                if (a[i].CompareTo(key) == 0)
                {
                    index = i;

                    return true;
                }
            }

            return false;
        }

        public static bool binarySearch(double[] a, double key, ref int index)
        {
            int low = 0;
            int high = a.Count() - 1;
            int mid;

            while (low <= high)
            {
                mid = low + ((high - low)/2);

                if (a[mid].CompareTo(key) == 0)
                {
                    index = mid;

                    return true; // key found
                }
                if (a[mid] < key)
                {
                    low = mid + 1;
                }
                else if (a[mid] > key)
                {
                    high = mid - 1;
                }
                else
                {
                    throw new Exception("muito triste isso :(");
                }
            }

            return false; // key not found.
        }

        private static ObservableCollection<Point> DatasetPoints;

        public static bool IndexFromDepth(double key, ref int index)
        {
            int low = 0;
            int high = DatasetPoints.Count - 1;
            int mid;

            while (low <= high)
            {
                mid = low + ((high - low)/2);

                if (DatasetPoints[mid].Y.CompareTo(key) == 0)
                {
                    index = mid;

                    return true; // key found
                }
                if (DatasetPoints[mid].Y < key)
                {
                    low = mid + 1;
                }
                else if (DatasetPoints[mid].Y > key)
                {
                    high = mid - 1;
                }
                else
                {
                    throw new Exception("muito triste isso :(");
                }
            }

            return false; // key not found.
        }

        public static void Main(string[] args)
        {
            // double test
            {
                Random random = new Random();
                HashSet<double> set = new HashSet<double>();
                double[] a = new double[1024*1024]; // usar 1024 * 32 com basicSearch ou não vai ficar velho esperando!

                {
                    double value;
                    for (int i = 0; i < a.Count();)
                    {
                        value = (double) random.Next()*1024/random.Next()*1024;

                        if (!set.Contains(value))
                        {
                            set.Add(value);
                            a[i] = value;
                            ++i;
                        }
                    }
                }

                Array.Sort(a);
                int index1 = 0, index2 = 0;

                for (int i = 0; i < a.Count(); ++i)
                {
                    //Debug.Assert(basicSearch(a, a[i], ref index1)); // usar 1024 * 32 com basicSearch ou não vai ficar velho esperando!
                    Debug.Assert(binarySearch(a, a[i], ref index2));

                    //Debug.Assert(index1 == index2);
                    Debug.Assert(i == index2);
                }
            }

            // Dataset test
            {
                Random random = new Random();
                HashSet<double> set = new HashSet<double>();
                DatasetPoints = new ObservableCollection<Point>();

                {
                    double value;
                    for (int i = 0; i < 1024*1024;)
                    {
                        value = (double) random.Next()*1024/random.Next()*1024;

                        if (!set.Contains(value))
                        {
                            set.Add(value);
                            DatasetPoints.Add(new Point(0, value));
                            ++i;
                        }
                    }
                }

                DatasetPoints = new ObservableCollection<Point>(DatasetPoints.OrderBy(c => c.Y));
                int index1 = 0, index2 = 0;

                for (int i = 0; i < DatasetPoints.Count(); ++i)
                {
                    Debug.Assert(IndexFromDepth(DatasetPoints[i].Y, ref index2));

                    //Debug.Assert(index1 == index2);
                    Debug.Assert(i == index2);
                }
            }
        }
    }
}
