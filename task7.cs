using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nНесамодвойственные булевы функции от трех переменных: ");

            for (int i = 0; i <= 1; i++)
            {
                for (int j = 0; j <= 1; j++)
                {
                    for (int k = 0; k <= 1; k++)
                    {
                        for (int l = 0; l <= 1; l++)
                        {
                            for (int m = 0; m <= 1; m++)
                            {
                                for (int n = 0; n <= 1; n++)
                                {
                                    for (int o = 0; o <= 1; o++)
                                    {
                                        for (int p = 0; p <= 1; p++)
                                        {
                                            if (i != p && j != o && k != n && l != m) { }
                                            else Console.WriteLine("{0}{1}{2}{3}{4}{5}{6}{7}", i, j, k, l, m, n, o, p);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
