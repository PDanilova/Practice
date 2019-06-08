using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\nВведите порядок квадратной матрицы: ");

            Random rand = new Random();
            bool check;
            int n;

            do
            {
                check = Int32.TryParse(Console.ReadLine(), out n);
                if (!check || n < 1) Console.WriteLine("\nОшибка! Введите натуральное число");
            } while (!check || n < 1);

            double[,] matr = new double[n, n];
            double element;

            Console.WriteLine("\nВыберите способ заполнения матрицы: ");
            Console.WriteLine("1 - Ручной ввод");
            Console.WriteLine("2 - Заполнить элементы автоматически");

            int choose;

            do
            {
                check = Int32.TryParse(Console.ReadLine(), out choose);
                if (!check || (choose != 1 && choose != 2)) Console.WriteLine("\nОшибка! Введите 1 или 2");
            } while (!check || (choose != 1 && choose != 2));

            switch (choose)
            {
                case 1: // ручной ввод

                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            Console.Write("\nВведите элемент матрицы {0} строки, {1} столбца: ", i + 1, j + 1);

                            do
                            {
                                check = double.TryParse(Console.ReadLine(), out element);
                                if (!check) Console.WriteLine("\nОшибка! Введите число");
                            } while (!check);

                            matr[i, j] = element;
                        }
                    }

                    break;

                case 2: //заполнить элементы автоматически

                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            matr[i, j] = rand.Next(-20, 20);
                        }
                    }

                    Console.WriteLine("\nМатрица создана...");
                    break;
            }

            Console.WriteLine("\nМатрица: ");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("       {0}", matr[i, j]);
                }
                Console.WriteLine();
            }

            double max = Double.MinValue;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++) //количество элементов
                {
                    if (j >= n - i - 1 && matr[i, j] >= max) max = matr[i, j];
                }
            }

            Console.Write("\nМаксимальный элемент = {0}", max);

            Console.ReadKey();
        }
    }

}
