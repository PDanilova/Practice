using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task12
{

    class Point
    {
        public int data;
        public Point left, right;
        public Point()
        {
            data = 0;
            left = null;
            right = null;
        }
        public Point(int d)
        {
            data = d;
            left = null;
            right = null;
        }
        public override string ToString()
        {
            return data + " ";
        }

        public void Clear()
        {
            this.data = 0;
            this.left = null;
            this.right = null;
        }

        public Point MakePoint(int d)//формирование  элемента дерева
        {
            Point p = new Point(d);
            return p;
        }
        //добавление элемента d в дерево поиска
        public Point Add(Point root, int d)
        {
            Point p = root;//корень дерева
            Point r = null;
            //флаг для проверки существования элемента d в дереве
            bool ok = false;
            while (p != null && !ok)
            {
                countEqual++;
                r = p;
                if (d == p.data) ok = true;//элемент уже существует
                else
               if (d < p.data) p = p.left;//пойти в левое поддерево
                else p = p.right; //пойти в правое поддерево
            }

            if (ok) return p;//найдено, не добавляем
                             
            Point NewPoint = MakePoint(d);

            // если d<r->key, то добавляем его в левое поддерево
            if (d < r.data)
            {
                r.left = NewPoint;
                countChange++;
            }

            // если d>r->key, то добавляем его в правое поддерево
            else
            {
                r.right = NewPoint;
                countChange++;
            }
            return NewPoint;
        }

        public int countChange = 0; //количество изменений
        public int countEqual = 0; //количество сравнений
    }

    class Program
    {
        static int countChange = 0; //количество изменений
        static int countEqual = 0; //количество сравнений
        
        public static void FirstSort (int [] array) //сортировка простыми вставками
        {
            countChange = 0;
            countEqual = 0;

            for (int i = 1; i < array.Length; i++)
            {
                int j;
                int buf = array[i];
                for (j = i - 1; j >= 0; j--)
                {
                    countEqual++;
                    if (array[j] < buf)
                        break;

                    array[j + 1] = array[j];
                    countChange++;
                }
                array[j + 1] = buf;
            }

            Console.WriteLine("\nКоличество сравнений: " + countChange);
            Console.WriteLine("Количество изменений: " + countEqual);

        }

        public static void SecondSort (int [] array) // сортировка бинарным деревом
        {
            Point tree = new Point();
            tree.countEqual = 0;
            tree.countChange = 0;

           foreach (int x in array)
           {
                tree.Add(tree, x);
           }

            Console.WriteLine("\nКоличество сравнений: " + tree.countEqual);
            Console.WriteLine("Количество изменений: " + tree.countChange);

        }

        static void Main(string[] args)
        {
            int[] arr = new int[] { -100, -95, -71, -54, -32, -16, 0, 4, 9, 33, 45, 99 }; //сортировка по возрастанию
            int[] arr2 = new int[] { 99, 45, 33, 9, 4, 0, -16, -32, -54, -71, -95, -100 }; //сортировка по убыванию
            int[] arr3 = new int[] { 0, 99, -95, 9, 33, 4, 45, -54, -100, -32, -16, -71 }; //массив не отсортирован

            Console.WriteLine("Сортировка простыми вставками:");
            Console.WriteLine("\nМассив, отсортированный по возрастанию: ");
            FirstSort(arr);

            Console.WriteLine("\nМассив, отсортированный по убыванию: ");
            FirstSort(arr2);

            Console.WriteLine("\nНеотсортированный массив: ");
            FirstSort(arr3);

            Console.WriteLine("\nСортировка с помощью двоичного дерева:");
            Console.WriteLine("\nМассив, отсортированный по возрастанию: ");
            SecondSort(arr);

            Console.WriteLine("\nМассив, отсортированный по убыванию: ");
            SecondSort(arr2);

            Console.WriteLine("\nНеотсортированный массив: ");
            SecondSort(arr3);

            Console.ReadKey();
        }
    }
}
