using System;
using System.IO;
using System.Text;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] vvod = Console.ReadLine().Split();
            string[] key = null;

            int str = int.Parse(vvod[0]);
            
            key = Console.ReadLine().Split();
            
            string text = Console.ReadLine(); //считываем сообщение
            
            int[] mas = new int[key.Length]; //массив из цифр ключа
            int j = 0;

            foreach (string ch in key) //переносим ключ в массив из цифр
            {
                bool ok = Int32.TryParse(ch, out mas[j]);
                j++;
            }

            char[][] table = new char[str][];

            int remainder = text.Length % str; //количество строк в последнем столбце

            int result = text.Length / str;

            int columns;

            if (remainder != 0) columns = result + 1;
            else columns = result;

            //определяем количество столбцов в каждой строке 
            if (remainder != 0)
            {
                for (int i = 0; i < remainder; i++) 
                {
                    table[i] = new char[columns];
                }
                for (int i = remainder; i < str; i++)
                {
                    table[i] = new char[columns - 1];
                }
            } 
            else
            {
                for (int i = 0; i < str; i++)
                {
                    table[i] = new char[columns];
                }
            }

            int charOfText = 0;

            //заполнение таблицы
            for (int i = 1; i <= str; i++)
            {
                int a = mas[i - 1];

                if (remainder != 0 && a <= remainder) //если это длинные строки
                {
                    for (int n = 0; n < columns; n++)
                    {
                        table[a - 1][n] = text[charOfText];
                        charOfText++;
                    }
                }
                else if (remainder == 0)
                {
                    for (int n = 0; n < columns; n++)
                    {
                        table[a - 1][n] = text[charOfText];
                        charOfText++;
                    }
                } else
                {
                    for (int n = 0; n < columns - 1; n++)
                    {
                        table[a - 1][n] = text[charOfText];
                        charOfText++;
                    }
                }
            }

            char[] newText = new char[text.Length];
            int number = 0;

            //перевод полученной таблицы в строку
            if (remainder == 0) //если количество строк с столбцах одинаковое
            {
                for (int i = 0; i< columns; i++)
                {
                    for (int n = 0; n < str; n++)
                    {
                        newText[number] = table[n][i];
                        number++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < columns - 1; i++)
                {
                    for (int n = 0; n < str; n++)
                    {
                        newText[number] = table[n][i];
                        number++;
                    }
                }
                for (int i = columns - 1; i < columns; i++)
                {
                    for (int n = 0; n < remainder; n++)
                    {
                        newText[number] = table[n][i];
                        number++;
                    }
                }
            }
            
            string res = new string(newText);
            Console.Write(res);

            Console.ReadKey();
            
        }
    }
}
