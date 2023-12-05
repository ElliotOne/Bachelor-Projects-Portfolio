using System;
using System.Collections.Generic;
using System.IO;

namespace MatrixSpeedTest
{
    static class Program
    {
        public static void simple(int[,] A)
        {
            for (int m = 0; m < A.GetLength(0); m++)
            {
                for (int n = 0; n < A.GetLength(0); n++)
                {
                    A[m, n] = m + n;
                }
            }
            int[,] result = new int[A.GetLength(0), A.GetLength(0)];
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(0); j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < A.GetLength(0); k++)
                    {
                        result[i, j] += A[i, k] * A[k, j];
                    }
                }
            }
        }
        public static Dictionary<int, double> GenerateSimple(int from,int to,int increase)
        {
            Dictionary<int, double> val = new Dictionary<int, double>();
            for (int m = from; m <= to; m = m + increase)
            {
                int[,] A = new int[m, m];
                Random rand = new Random();
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    for (int j = 0; j < A.GetLength(1); j++)
                    {
                        A[i, j] = rand.Next(0, 5);
                    }
                }

                var myTime = System.Diagnostics.Stopwatch.StartNew();

                simple(A);

                myTime.Stop();
                val.Add(m, (myTime.ElapsedMilliseconds * Math.Pow(10, 6)));
            }
            return val;
        }



        public static int[,] strassen(int[,] First, int[,] Second)
        {
            int n = First.GetLength(0);
            int[,] result = new int[n, n];

            if ((n % 2 != 0) && (n != 1))
            {
                int[,] a1, b1, c1;
                int n1 = n + 1;
                a1 = new int[n1, n1];
                b1 = new int[n1, n1];
                c1 = new int[n1, n1];

                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                    {
                        a1[i, j] = First[i, j];
                        b1[i, j] = Second[i, j];
                    }
                c1 = strassen(a1, b1);
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        result[i, j] = c1[i, j];
                return result;
            }

            if (n == 1)
            {
                result[0, 0] = First[0, 0] * Second[0, 0];
            }
            else
            {
                int[,] A11 = new int[n / 2, n / 2];
                int[,] A12 = new int[n / 2, n / 2];
                int[,] A21 = new int[n / 2, n / 2];
                int[,] A22 = new int[n / 2, n / 2];
                                 
                int[,] B11 = new int[n / 2, n / 2];
                int[,] B12 = new int[n / 2, n / 2];
                int[,] B21 = new int[n / 2, n / 2];
                int[,] B22 = new int[n / 2, n / 2];

                divide(First, A11, 0, 0);
                divide(First, A12, 0, n / 2);
                divide(First, A21, n / 2, 0);
                divide(First, A22, n / 2, n / 2);

                divide(Second, B11, 0, 0);
                divide(Second, B12, 0, n / 2);
                divide(Second, B21, n / 2, 0);
                divide(Second, B22, n / 2, n / 2);

                int[,] P1 = strassen(add(A11, A22), add(B11, B22));
                int[,] P2 = strassen(add(A21, A22), B11);
                int[,] P3 = strassen(A11, sub(B12, B22));
                int[,] P4 = strassen(A22, sub(B21, B11));
                int[,] P5 = strassen(add(A11, A12), B22);
                int[,] P6 = strassen(sub(A21, A11), add(B11, B12));
                int[,] P7 = strassen(sub(A12, A22), add(B21, B22));
                
                int[,] C11 = add(sub(add(P1, P4), P5), P7);
                int[,] C12 = add(P3, P5);
                int[,] C21 = add(P2, P4);
                int[,] C22 = add(sub(add(P1, P3), P2), P6);

                copy(C11, result, 0, 0);
                copy(C12, result, 0, n / 2);
                copy(C21, result, n / 2, 0);
                copy(C22, result, n / 2, n / 2);
            }
            return result;
        }
        public static int[,] add(int[,] A, int[,] B)
        {
            int n = A.GetLength(0);

            int[,] result = new int[n, n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    result[i, j] = A[i, j] + B[i, j];

            return result;
        }
        public static int[,] sub(int[,] A, int[,] B)
        {
            int n = A.GetLength(0);

            int[,] result = new int[n, n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    result[i, j] = A[i, j] - B[i, j];

            return result;
        }
        public static void divide(int[,] p1, int[,] c1, int iB, int jB)
        {
            for (int i1 = 0, i2 = iB; i1 < c1.GetLength(0); i1++, i2++)
                for (int j1 = 0, j2 = jB; j1 < c1.GetLength(0); j1++, j2++)
                {
                    c1[i1, j1] = p1[i2, j2];
                }
        }
        public static void copy(int[,] c1, int[,] p1, int iB, int jB)
        {
            for (int i1 = 0, i2 = iB; i1 < c1.GetLength(0); i1++, i2++)
                for (int j1 = 0, j2 = jB; j1 < c1.GetLength(0); j1++, j2++)
                {
                    p1[i2, j2] = c1[i1, j1];
                }
        }
        public static Dictionary<int,double> GenerateStrassen(int from, int to, int increase)
        {
            Dictionary<int, double> val = new Dictionary<int, double>();
            for (int m = from; m <= to; m = m + increase)
            {
                int[,] A = new int[m, m];
                Random rand = new Random();
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    for (int j = 0; j < A.GetLength(1); j++)
                    {
                        A[i, j] = rand.Next(0, 5);
                    }
                }

                var myTime = System.Diagnostics.Stopwatch.StartNew();

                strassen(A,A);

                myTime.Stop();
                val.Add(m, (myTime.ElapsedMilliseconds * Math.Pow(10, 6)));
            }
            return val;
        }

       
        static void Main(string[] args)
        {
            Console.Write("From : ");
            int from = int.Parse(Console.ReadLine());
            Console.Write("To : ");
            int to = int.Parse(Console.ReadLine());
            Console.Write("Increase By : ");
            int increase = int.Parse(Console.ReadLine());

            try
            {
                StreamWriter sw = new StreamWriter("data.txt", true);
                Dictionary<int, double> dict1 = GenerateSimple(from, to, increase);
                Console.WriteLine("==================== Simple Matrix ====================");
                sw.WriteLine("==================== Simple Matrix ====================");
                Console.WriteLine("Count\t\tTime(ns)");
                sw.WriteLine("Count\t\tTime(ns)");
                foreach (KeyValuePair<int, double> item in dict1)
                {
                    Console.WriteLine(item.Key + "\t\t" + item.Value);
                    sw.WriteLine(item.Key + "\t\t" + item.Value);
                }

                Console.WriteLine("==============================================");
                Console.WriteLine("==============================================");
                Console.WriteLine("==============================================");

                Dictionary<int, double> dict2 = GenerateStrassen(from, to, increase);
                Console.WriteLine("==================== Strassen Matrix ====================");
                sw.WriteLine("==================== Strassen Matrix ====================");
                Console.WriteLine("Count\t\tTime(ns)");
                sw.WriteLine("Count\t\tTime(ns)");
                foreach (KeyValuePair<int, double> item in dict2)
                {
                    Console.WriteLine(item.Key + "\t\t" + item.Value);
                    sw.WriteLine(item.Key + "\t\t" + item.Value);
                }
                sw.Close();
                Console.WriteLine("Finished ... press any key to exit.");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           

        }
    }
}
