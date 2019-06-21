using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10
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
        
    }
    
    class Program
    {
        public static Random rnd = new Random();

        static int GetInfo()
        {
            int info = rnd.Next(0, 10);
            Console.WriteLine("Элемень {0} добавлен...", info);
            return info;
        }

        //формирование идеально-сбалансированного дерева
        static Point IdealTree(int size, Point p)
        {
            Point r;
            int nl, nr;
            if (size == 0) { p = null; return p; }
            nl = size / 2;
            nr = size - nl - 1;
            int d = GetInfo();
            r = new Point(d);
            r.left = IdealTree(nl, r.left);
            r.right = IdealTree(nr, r.right);
            p = r;
            return p;
        }

        //печать дерева по уровням
        static void ShowTree(Point p, int l)
        {
            if (p != null)
            {
                ShowTree(p.left, l + 3);//переход к левому поддереву
                for (int i = 0; i < l; i++) Console.Write(" ");
                Console.WriteLine(p.data);
                ShowTree(p.right, l + 3);//переход к правому поддереву
            } 
        }

        static void Main(string[] args)
        {
            //формируем дерево
            int size = rnd.Next(5, 20);
            Point idTree = null;
            idTree = IdealTree(size, idTree);

            //выводим на печать
            ShowTree(idTree, 5);

            //удаляем
            idTree.Clear();

            Console.WriteLine("\nУдаление...");

            if (idTree.data == 0) Console.WriteLine("\nДерево пустое!");
            else ShowTree(idTree, 5);

            Console.ReadKey();
        }
    }
}
