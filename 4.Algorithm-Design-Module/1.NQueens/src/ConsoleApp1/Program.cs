using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static FileStream fs = new FileStream("data.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
        static StreamWriter sw = new StreamWriter(fs);
        static void Main(string[] args)
        {
            //start from 4 to 16
            Dictionary<int, double> data = RunAlgorithm(16);
            try
            {

                sw.WriteLine("N\t\t\tTime(ns)");
                foreach (KeyValuePair<int, double> item in data)
                {
                    sw.WriteLine(item.Key + "\t\t" + item.Value);
                }
                sw.Close();
                Console.WriteLine("********************** Finished **********************");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            Console.ReadLine();
        }

        public static Dictionary<int, double> RunAlgorithm(int count)
        {
            Dictionary<int, double> values = new Dictionary<int, double>();
            Stopwatch time = new Stopwatch();
            for (int i = 4; i <= count; i = i * 2)
            {
                time.Start();
                NQueenFunction(i);
                time.Stop();
                values.Add(i, time.ElapsedMilliseconds * Math.Pow(10, 6));
            }
            return values;
        }

        public static void NQueenFunction(int count)
        {
            var obj = new Program();
            int[,] boardMatrix = new int[count, count];

            if (obj.ProcessNQueen(0, count, boardMatrix))
            {
                Console.WriteLine("Solution: ");
                for (var i = 0; i < count; i++)
                {
                    for (var j = 0; j < count; j++)
                    {
                        Console.Write("  " + boardMatrix[i, j] + "  ");
                        sw.Write("  " + boardMatrix[i, j] + "  ");
                    }
                    Console.WriteLine("\n");
                    sw.WriteLine("\n");
                }
                Console.WriteLine("\n");
                sw.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("There is no solution!");
                sw.WriteLine("There is no solution!");
            }
        }

        public bool IsFieldAvailable(int row, int col, int[,] boardMatrix)
        {
            for (int i = 0; i < col; i++)
            {
                if (boardMatrix[row, i] == 1) return false;
            }
            for (int i = row, j = col; i < boardMatrix.GetLength(0) && j < boardMatrix.GetLength(1); i++, j++)
            {
                if (boardMatrix[i, j] == 1) return false;
            }
            for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)
            {
                if (boardMatrix[i, j] == 1) return false;
            }
            for (int i = row, j = col; i < boardMatrix.GetLength(0) && j >= 0; i++, j--)
            {
                if (boardMatrix[i, j] == 1) return false;
            }
            for (int i = row, j = col; i >= 0 && j < boardMatrix.GetLength(1); i--, j++)
            {
                if (boardMatrix[i, j] == 1) return false;
            }
            return true;
        }

        public bool ProcessNQueen(int col, int nQueen, int[,] boardMatrix)
        {
            if (col >= nQueen) return true;

            for (int i = 0; i < boardMatrix.GetLength(0); i++)
            {
                if (IsFieldAvailable(i, col, boardMatrix))
                {
                    boardMatrix[i, col] = 1;

                    if (ProcessNQueen(col + 1, nQueen, boardMatrix))
                    {
                        return true;
                    }
                    boardMatrix[i, col] = 0;
                }
            }

            return false;
        }
    }
}
