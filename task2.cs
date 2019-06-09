using System;
using System.IO;
using System.Text;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string key;
            string str;
            string text;

            StreamReader sr = new StreamReader("input.txt", Encoding.GetEncoding(1251));

                str = sr.ReadLine(); //считываем количество строк
                key = sr.ReadLine(); //считываем ключ
                text = sr.ReadLine(); //считываем сообщение
            
            bool ok = Int32.TryParse(str, out int strings);

            string[] kkey = key.Split(new char[] { ' ' }); //переносим ключ в массив

            int[] mas = new int[kkey.Length]; //массив из цифр ключа
            int j = 0;

            foreach (string ch in kkey) //переносим ключ в массив из цифр
            {
                ok = Int32.TryParse(ch, out mas[j]);
                j++;
            }

            char[][] table = new char[strings][];

            int remainder = text.Length % strings; //количество столбцов в последней строке

            double result = text.Length / strings;

            int columns = Convert.ToInt32(Math.Ceiling(result)); //число основных столбцов

            int k;

            if (remainder == 0) k = strings;
            else k = strings - 1;

            //определяем количество столбцов в каждой строке 
            if (!(remainder == 0))
            {
                for (int i = 0; i < strings - 1; i++)
                {
                    table[i] = new char[columns];
                }

                table[strings - 1] = new char[remainder];
            } 
            else
            {
                for (int i = 0; i < strings; i++)
                {
                    table[i] = new char[columns];
                }
            }

            int charOfText = 0;

            //заполнение таблицы
            for (int i = 1; i <= strings; i++)
            {
                int a = mas[i - 1];

                if (remainder != 0 && a == strings - 1) //если это последняя строка с неполным кол-вом столбцов
                {
                    for (int n = 0; n < remainder; n++)
                    {
                        table[strings - 1][n] = text[charOfText];
                        charOfText++;
                    }
                }
                else
                {
                    for (int n = 0; n < columns; n++)
                    {
                        table[a - 1][n] = text[charOfText];
                        charOfText++;
                    }
                }
            }

            char[] newText = new char[text.Length];
            int number = 0;

            //перевод полученной таблицы в строку
            if (remainder == 0) //если количество столбцов в последней строке полное
            {
                for (int i = 0; i< columns; i++)
                {
                    for (int n = 0; n < strings; n++)
                    {
                        newText[number] = table[n][i];
                        number++;
                        Console.Write(table[n][i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < remainder; i++)
                {
                    for (int n = 0; n < strings; n++)
                    {
                        newText[number] = table[n][i];
                        number++;
                        Console.Write(table[n][i]);
                    }
                }
                for (int i = remainder; i < columns; i++)
                {
                    for (int n = 0; n < strings - 1; n++)
                    {
                        newText[number] = table[n][i];
                        number++;
                    }
                }
            }
            
            StreamWriter sw = new StreamWriter("output.txt");
            sw.WriteLine(newText);
            
            sr.Close();
            sw.Close();

            Console.ReadKey();
        }
    }
}
