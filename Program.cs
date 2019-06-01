using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24
{
    class Program
    {
        static double Enter()
        {
            bool check;
            double coord;

            do
            {
                check = Double.TryParse(Console.ReadLine(), out coord);
                if (!check) Console.WriteLine("\nОшибка! Введите рациональное число.");
            } while (!check);

            return coord;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("\n     Задание №3");
            Console.Write("\nВам нужно ввести координаты точки.   \n   Введите х:  ");
            double x = Enter();
            Console.Write("   Введите y: ");
            double y = Enter();

            bool condition = false;
            double u = 0;

            if ((y <= 1 - x * x) && x * x + Math.Pow((y - 1), 2) <= 1) condition = true; //проверка принадлежности к заштрихованной области

            switch (condition)
            {
                case true: //если точка входит в закрашенную область
                    u = x - y;
                    break;

                case false: //если точка не входит в закрашенную область
                    u = x * y + 7;
                    break;
            }

            Console.WriteLine("\n   U = " + u);
            Console.ReadKey();
        }
    }
}
