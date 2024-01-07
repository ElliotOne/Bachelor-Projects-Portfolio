using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int tempSize = 0;
            int error = 0;
            string inputString;
           
            Console.Write("Enter template count : ");
            tempSize = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter input string (use , to separate) : ");
            inputString = Console.ReadLine();

            string[] arrString = inputString.Split(',');
            List<string> list = new List<string>();
            foreach (var item in arrString)
            {
                list.Add(item);
            }

            List<string> template = new List<string>(tempSize);
            Dictionary<string, int> map = new Dictionary<string, int>();


            Console.WriteLine();
            Console.WriteLine("**************** Optimized ****************");
            for (int i = 0; i < list.Count; i++)
            {
                string inp = list[i];
                if (template.Count != tempSize)
                {
                    if (!template.Contains(inp))
                    {
                        template.Add(inp);
                    }
                }
                else
                {
                    if (!template.Contains(inp))
                    {
                        if (i == list.Count - 1)
                        {
                            template.RemoveAt(0);
                            template[0] = inp;
                        }
                        else
                        {
                            if (!template.Contains(inp))
                            {
                                error++;
                                List<string> temp = new List<string>();
                                for (int j = 0; j < template.Count; j++)
                                {
                                    temp.Add(template[j]);
                                }
                                String last = "";
                                int index;
                                for (int j = i + 1; j <= list.Count; j++)
                                {
                                    if (j == list.Count)
                                    {
                                        last = temp[temp.Count - 1];
                                        break;
                                    }
                                    if (temp.Count == 1)
                                    {
                                        last = temp[temp.Count - 1];
                                        break;
                                    }
                                    if (template.Contains(list[j]))
                                    {
                                        temp.Remove(list[j]);
                                    }
                                }
                                index = template.IndexOf(last);
                                template[index] = inp;
                            }
                        }
                    }
                }
                Print(template);
            }
            Console.WriteLine("Errors = " + error);

            Console.WriteLine();
            Console.WriteLine("**************** LRU ****************");
            error = 0;
            template.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                string inp = list[i];
                if (template.Count != tempSize)
                {
                    if (!template.Contains(inp))
                    {
                        template.Add(inp);
                    }
                }
                else
                {
                    if (!template.Contains(inp))
                    {
                        error++;
                        List<string> temp = new List<string>();
                        for (int j = 0; j < template.Count; j++)
                        {
                            temp.Add(template[j]);
                        }
                        string last = "";
                        for (int j = i; j >= 0; j--)
                        {
                            if (temp.Count == 1)
                            {
                                last = temp[temp.Count - 1];
                                break;
                            }
                            if (template.Contains(list[j]))
                            {
                                temp.Remove(list[j]);
                            }
                        }
                        int index = template.IndexOf(last);
                        template[index] =  inp;
                    }
                }
                Print(template);
            }

            Console.WriteLine("Errors = " + error);

            Console.WriteLine();
            Console.WriteLine("**************** FIFO ****************");
            error = 0;
            template.Clear();
            List<string> saf = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                string inp = list[i];
                if (template.Count != tempSize)
                {
                    if (!template.Contains(inp))
                    {
                        template.Add(inp);
                        saf.Add(inp);
                    }
                }
                else
                {
                    if (!template.Contains(inp))
                    {
                        error++;
                        int index = template.IndexOf(saf[0]);
                        template[index] = inp;
                        saf.RemoveAt(0);
                        saf.Add(inp);
                    }
                }
                Print(template);
            }

            Console.WriteLine("Errors = " + error);


            Console.ReadLine();
        }

        private static void Print(List<string> list)
        {
            Console.WriteLine("************** RAM");
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(i);
                Console.Write("---");
                Console.Write(list[i]);
                Console.WriteLine();
            }
            Console.WriteLine("**************");
        }
    }
}
