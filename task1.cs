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

            for (int i = 0; i < m; i++)
            {
                string [] numbers  = Console.ReadLine().Split();
                int first = int.Parse(numbers[0]);
                int second = int.Parse(numbers[1]);
                
                if (first > second)
                {
                    table[0, second - 1] = first;
                }
                else
                {
                    table[0, first - 1] = second;
                }
                
            }

            SortedDictionary<int, int> colbs = new SortedDictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; i++)
                {
                    if (i != j && table[0, i] == table[0, j])
                    {
                        int sum = table[1, i] + table[1, j];
                        colbs.Add(table[0, i], sum);
                    }
                }
            }

            foreach ()

            Console.ReadKey();

        }
    }
}
