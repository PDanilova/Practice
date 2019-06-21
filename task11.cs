using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nВведите 1, если хотите ввести фразу из 100 символов самостоятельно");
            Console.WriteLine("\nВведите 2, если хотите использовать готовую фразу");

            int choose;
            bool check;

            do
            {
                check = Int32.TryParse(Console.ReadLine(), out choose);
                if (choose != 1 && choose != 2) Console.WriteLine("\nОшибка ввода!");
            } while (choose != 1 && choose != 2);

            string text = null;

            switch (choose)
            {
                case 1:
                    Console.WriteLine("\nВведите текст: ");
                    do
                    {
                        text = Console.ReadLine();
                        if (text.Length != 100) Console.WriteLine("\nОшибка! Текст должен содержать ровно 100 символов");
                    } while (text.Length != 100);
                    break;

                case 2:
                    text = "С помощью данного онлайн-сервиса можно определить число слов в тексте, а также количество символов .";
                    break;
            }

            Console.WriteLine("\nТекст для шифрования: ");
            Console.WriteLine(text);

            char[] text2 = text.ToCharArray();

            int[,] matr = new int[10, 10] { {1, 0, 1, 0, 0, 1, 0, 0, 1, 1 },
                                            {1, 1, 1, 1, 1, 1, 1, 1, 0, 1 },
                                            {1, 1, 0, 1, 1, 0, 0, 1, 1, 1 },
                                            {1, 1, 1, 0, 1, 1, 1, 1, 1, 1 },
                                            {1, 0, 1, 1, 0, 1, 1, 0, 1, 1},
                                            {1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                                            {1, 0, 0, 1, 0, 0, 1, 1, 1, 1 }, 
                                            {0, 1, 1, 1, 1, 1, 1, 1, 0, 1 }, 
                                            {1, 1, 1, 0, 1, 0, 1, 0, 1, 1 },
                                            {1, 0, 1, 1, 1, 1, 1, 1, 1, 0 } };
            char[,] table = new char[10, 10];

            Console.WriteLine("\nКлюч: ");
            Console.WriteLine("    1 0 1 0 0 1 0 0 1 1");
            Console.WriteLine("    1 1 1 1 1 1 1 1 0 1");
            Console.WriteLine("    1 1 0 1 1 0 0 1 1 1");
            Console.WriteLine("    1 1 1 0 1 1 1 1 1 1");
            Console.WriteLine("    1 0 1 1 0 1 1 0 1 1");
            Console.WriteLine("    1 1 1 1 1 1 1 1 1 0");
            Console.WriteLine("    1 0 0 1 0 0 1 1 1 1");
            Console.WriteLine("    0 1 1 1 1 1 1 1 0 1");
            Console.WriteLine("    1 1 1 0 1 0 1 0 1 1");
            Console.WriteLine("    1 0 1 1 1 1 1 1 1 0");

            int k = 0;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (matr[i, j] == 0)
                    {
                        table[i, j] = text2[k];
                        k++;
                    }
                }
            }

            //поворот на 90 градусов
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (matr[10 - j - 1, i] == 0) 
                    {
                        table[i, j] = text2[k];
                        k++;
                    }
                }
            }

            //поворот на 180 градусов
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (matr[10 - i - 1, 10 - j - 1] == 0)
                    {
                        table[i, j] = text2[k];
                        k++;
                    }
                }
            }

            //поворот на 270 градусов
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (matr[j, 10 - i - 1] == 0)
                    {
                        table[i, j] = text2[k];
                        k++;
                    }
                }
            }

            Console.WriteLine("\nЗашифрованный текст: ");
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(" " + table[i,j]);
                }
                Console.WriteLine();
            }

            //расшифровка текста
            Console.WriteLine("\nРасшифрованный текст: ");

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (matr[i, j] == 0)
                    {
                        Console.Write(table[i,j]);
                    }
                }
            }

            //поворот на 90 градусов
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (matr[10 - j - 1, i] == 0)
                    {
                        Console.Write(table[i,j]);
                    }
                }
            }

            //поворот на 180 градусов
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (matr[10 - i - 1, 10 - j - 1] == 0)
                    {
                        Console.Write(table[i,j]);
                    }
                }
            }

            //поворот на 270 градусов
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (matr[j, 10 - i - 1] == 0)
                    {
                        Console.Write(table[i,j]);
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
