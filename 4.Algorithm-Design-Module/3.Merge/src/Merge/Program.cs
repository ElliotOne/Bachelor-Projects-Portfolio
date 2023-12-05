using System;
using System.Collections.Generic;
using System.IO;

namespace Merge
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = 2;
            int end = 1000;
            int step = 1;

            Dictionary<int, double> dataNormal = GenerateMergeNormal(start, end, step);
            Dictionary<int, double> dataSmart = GenerateMergeSmart(start, end, step);

            try
            {
                StreamWriter sw = new StreamWriter("data.txt", true);

                for (int i = start; i <= end; i = i + step)
                {
                    sw.WriteLine($"{i}\t{dataNormal[i]}\t{dataSmart[i]}");
                }

                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static int[] createArray(int n)
        {
            int[] a = new int[n];
            Random ran = new Random();
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = ran.Next(int.MinValue, int.MaxValue);
            }
            return a;
        }

        static Dictionary<int, double> GenerateMergeNormal(int startNum, int endNum, int step)
        {
            Dictionary<int, double> values = new Dictionary<int, double>();
            for (int i = startNum; i <= endNum; i = i + step)
            {
                var myTimer = System.Diagnostics.Stopwatch.StartNew();

                mergeNormal(createArray(i), i);

                myTimer.Stop();
                values.Add(i, myTimer.Elapsed.TotalMilliseconds * Math.Pow(10, 6));
            }
            return values;
        }

        static Dictionary<int, double> GenerateMergeSmart(int startNum, int endNum, int step)
        {
            Dictionary<int, double> values = new Dictionary<int, double>();
            for (int i = startNum; i <= endNum; i = i + step)
            {
                var myTimer = System.Diagnostics.Stopwatch.StartNew();

                mergeSmart(createArray(i), i);

                myTimer.Stop();
                values.Add(i, myTimer.Elapsed.TotalMilliseconds * Math.Pow(10, 6));
            }
            return values;
        }

        public static void mergeNormal(int[] a, int n)
        {
            if (n < 2)
            {
                return;
            }
            int mid = n / 2;
            int[] l = new int[mid];
            int[] r = new int[n - mid];

            for (int i = 0; i < mid; i++)
            {
                l[i] = a[i];
            }
            for (int j = mid; j < n; j++)
            {
                r[j - mid] = a[j];
            }

            mergeNormal(l, mid);
            mergeNormal(r, n - mid);
            merge(a, l, r, mid, n - mid);
        }

        public static void mergeSmart(int[] a, int n)
        {
            if (n == 2)
            {
                if (a[0] > a[1])
                {
                    int t = a[0];
                    a[0] = a[1];
                    a[1] = t;
                }
            }
            int mid = n / 2;
            if (mid == 0)
            {
                return;
            }
            int[] l = new int[mid];
            int[] r = new int[n - mid];
            for (int i = 0; i < mid; i++)
            {
                l[i] = a[i];
            }
            for (int i = mid; i < n; i++)
            {
                r[i - mid] = a[i];
            }

            mergeSmart(l, mid);
            mergeSmart(r, n - mid);
            merge(a, l, r, mid, n - mid);

        }

        public static void merge(int[] a, int[] l, int[] r, int left, int right)
        {

            int i = 0, j = 0, k = 0;
            while (i < left && j < right)
            {
                if (l[i] <= r[j])
                {
                    a[k++] = l[i++];
                }
                else
                {
                    a[k++] = r[j++];
                }
            }
            while (i < left)
            {
                a[k++] = l[i++];
            }
            while (j < right)
            {
                a[k++] = r[j++];
            }
        }

    }
}
