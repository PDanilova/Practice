using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    class Program
    {
        static double Fact (double number)
        {
            if (number < 0)
                return 0;
            if (number == 0)
                return 1;
            else
                return number * Fact(number - 1);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("\n   Задание №4. Вариант 119г");

            Console.WriteLine("\n   Введите точность вычислений: ");

            double epsilon;
            bool check;

            do
            {
                check = double.TryParse(Console.ReadLine(), out epsilon);
                if (!check || epsilon <= 0) Console.WriteLine("\nОшибка! Введите положительное число");
            } while (!check || epsilon <= 0);

            double sum = 0;
            int i = 1;
            double sl;

            while (true)
            {
                sl = Math.Pow(-2, i) / Fact(i);
                if (Math.Abs(sl) < epsilon) break;
                sum += sl;
                i++;
            }

            Console.WriteLine("\nСумма ряда: " + sum);
            Console.ReadKey();

        }
    }
}
