using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string [] vvod = Console.ReadLine().Split();

            int n = int.Parse(vvod[0]);
            int m = int.Parse(vvod[1]);
            
            int[,] table = new int[2, n];

            string[] V = Console.ReadLine().Split();

            for (int i = 0; i < n; i++) 
            {
                int value = int.Parse(V[i]);
                
                table[0, i] = i + 1;
                table[1, i] = value;

            }

            int r = 0;

            for (int i = 0; i < m; i++)
            {
                string [] numbers  = Console.ReadLine().Split();
                int first = int.Parse(numbers[0]);
                int second = int.Parse(numbers[1]);
                
                if (table[0,first - 1] > table[0,second - 1])
                {
                    r = table[0, second - 1];
                    for (int k = 0; k < n; k++)
                    {
                        if (table [0,k] == r)
                        {
                            table[0, k] = table[0, first - 1];
                        }
                    }
                }
                else
                {
                    r = table[0, first - 1];
                    for (int k = 0; k < n; k++)
                    {
                        if (table[0, k] == r)
                        {
                            table[0, k] = table[0, second - 1];
                        }
                    }
                }
                
            }

            SortedDictionary<int, int> colbs = new SortedDictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                if (!colbs.ContainsKey(table[0,i]))
                {
                    colbs.Add(table[0, i], table[1, i]);
                }
                else
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (table [0,j]== table[0, i])
                        {
                            sum = sum + table[1, j];
                        }
                    }
                    colbs[table[0, i]] = sum;
                }
                
            }

            foreach (var x in colbs)
            {
                Console.WriteLine("{0} {1}", x.Key, x.Value);
            }
        }
    }
}
