using System;
using System.Collections.Generic;
using System.IO;

namespace FibAndQuick
{
    class Program
    {

        public static void myFib(int num, bool iSSmartFib)
        {
            int returnValue;

            if (iSSmartFib == true)
            {
                Dictionary<int, int> smartData = new Dictionary<int, int>();
                int smartFib(int m)
                {
                    if (m == 0 || m == 1)
                    {
                        return m;
                    }
                    else
                    {
                        if (smartData.ContainsKey(m))
                        {
                            return smartData[m];
                        }
                        int res = smartFib(m - 1) + smartFib(m - 2);
                        smartData.Add(m, res);
                        return res;
                    }
                }
                returnValue = smartFib(num);
            }
            else
            {
                int fib(int n)
                {
                    if (n == 0 || n == 1)
                    {
                        return n;
                    }
                    else
                    {
                        return fib(n - 1) + fib(n - 2);
                    }
                }

                returnValue = fib(num);
            }
        }


        public static Dictionary<int, double> fibGenerator(bool iSSmartFib)
        {
            Dictionary<int, double> val = new Dictionary<int, double>();
            int counter;
            for (int i = 1; i < 35; i++)
            {
                counter = i;
                var myTimer = System.Diagnostics.Stopwatch.StartNew();

                if (iSSmartFib == true)
                {
                    myFib(i, true);
                }
                else
                {
                    myFib(i, false);
                }

                myTimer.Stop();

                val.Add(counter, myTimer.Elapsed.TotalMilliseconds * Math.Pow(10, 6));
            }
            return val;
        }

        //------------------------------ Sort --------------------------------
        static int partition(int[] arr, int start, int end)
        {
            int pivot = arr[end];
            int x = (start - 1);
            for (int y = start; y < end; y++)
            {
                if (arr[y] <= pivot)
                {
                    x++;

                    int temp = arr[x];
                    arr[x] = arr[y];
                    arr[y] = temp;
                }
            }

            int temp1 = arr[x + 1];
            arr[x + 1] = arr[end];
            arr[end] = temp1;

            return x + 1;
        }
        static void Quick(int[] arr, int start, int end)
        {
            if (start < end)
            {
                int pi = partition(arr, start, end);

                Quick(arr, start, pi - 1);
                Quick(arr, pi + 1, end);
            }
        }

        private static int[] CreateArraySorted(int len)
        {
            int[] nums = new int[len];
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = i;
            }
            return nums;
        }

        private static int[] CreateArrayRandom(int len)
        {
            int[] nums = new int[len];
            Random rand = new Random();
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = rand.Next(0,9);
            }
            return nums;
        }


        public static Dictionary<int, double> quickGenerator(bool isSortedArray)
        {
            Dictionary<int, double> vals = new Dictionary<int, double>();

            for (int i = 100; i < 10000; i = i + 100)
            {
                int counter = i;

                var myTimer = System.Diagnostics.Stopwatch.StartNew();

                if (isSortedArray == true)
                {
                    Quick(CreateArraySorted(i), 0, i - 1);
                }
                else
                {
                    Quick(CreateArrayRandom(i), 0, i - 1);
                }

                myTimer.Stop();

                vals.Add(counter, myTimer.Elapsed.TotalMilliseconds * Math.Pow(10, 6));
            }
            return vals;
        }


        //------------------------- Main -------------------------


        static void Main(string[] args)
        {
            //smart fib
            Dictionary<int, double> dic1 = fibGenerator(true);
            //normal fib
            Dictionary<int, double> dic2 = fibGenerator(false);
            //quick sort - best case(it is random)
            Dictionary<int, double> dic3 = quickGenerator(false);
            //quick sort - worst case(it is sorted)
            Dictionary<int, double> dic4 = quickGenerator(true);

            StreamWriter sw = new StreamWriter("data.txt", true);
            try
            {
                sw.WriteLine("----------------- smart fib -----------------");
                Console.WriteLine("----------------- smart fib -----------------");
                foreach (KeyValuePair<int,double> item in dic1)
                {
                    sw.WriteLine(item.Key+"\t\t"+item.Value);
                    Console.WriteLine(item.Key + "\t\t" + item.Value);
                }

                sw.WriteLine("----------------- normal fib -----------------");
                Console.WriteLine("----------------- normal fib -----------------");
                foreach (KeyValuePair<int,double> item in dic2)
                {
                    sw.WriteLine(item.Key + "\t\t" + item.Value);
                    Console.WriteLine(item.Key + "\t\t" + item.Value);
                }

                sw.WriteLine("----------------- quick sort - best case(it is random) -----------------");
                Console.WriteLine("----------------- quick sort - best case(it is random) -----------------");
                foreach (KeyValuePair<int, double> item in dic3)
                {
                    sw.WriteLine(item.Key + "\t\t" + item.Value);
                    Console.WriteLine(item.Key + "\t\t" + item.Value);
                }

                sw.WriteLine("----------------- quick sort - worst case(it is sorted) -----------------");
                Console.WriteLine("----------------- quick sort - worst case(it is sorted) -----------------");
                foreach (KeyValuePair<int, double> item in dic4)
                {
                    sw.WriteLine(item.Key + "\t\t" + item.Value);
                    Console.WriteLine(item.Key + "\t\t" + item.Value);
                }

                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
}
