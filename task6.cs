using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task6
{
    class Program
    {
        public static double CheckDouble ()
        {
            bool check;
            double d;

            do
            {
                check = double.TryParse(Console.ReadLine(), out d);
                if (!check) Console.WriteLine("\nОшибка! Введите число");
            } while (!check);

            return d;
        }

        public static void Current(double a1, double a2, double a3, double m, int count)
        {
            count++;
            double current = a1 / 2 + a2 / 2 + a3 / 2;

            if (current > m && !double.IsInfinity(current))
            {
                Console.Write(",  " + current);
                Current(a2, a3, current, m, count);
            }
            else
            {
                if (double.IsInfinity(current)) Console.WriteLine("\nНевозможно выполнить заданное неравенство!");
                Console.WriteLine("\nНомер последнего элемента: {0}", count - 1);
                if (current.Equals(m)) Console.WriteLine("Элемент равен границе");
                else Console.WriteLine("Элемент не равен границе");
            }
        }

        static void Main(string[] args)
        {
            Console.Write("\nВведите a1: ");
            double a1 = CheckDouble();

            Console.Write("\nВведите a2: ");
            double a2 = CheckDouble();

            Console.Write("\nВведите a3: ");
            double a3 = CheckDouble();

            Console.Write("\nВведите M: ");
            double M = CheckDouble();

            int num = 3;

            Console.WriteLine("\nПоследовательность: ");
            Console.Write("{0},  {1},  {2}", a1, a2, a3);
            Current(a1, a2, a3, M, num);

            Console.ReadKey();
        }
    }
}
