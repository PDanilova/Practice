using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace task9
{
    public class Point<T>
    {
        public T Data { get; set; }
        public Point<T> Next { get; set; }

        public Point (T data)
        {
            Data = data;
        }
    }

    public class CircularLinkedList<T> : IEnumerable<T>
    {
        Point<T> head; //первый элемент
        Point<T> tail; //последний элемент
        int count; //количество элементов в списке

        public int Count { get { return count; } }

        public void Add(T data)
        {
            Point<T> node = new Point<T>(data);
            // если список пуст
            if (head == null)
            {
                head = node;
                tail = node;
                tail.Next = head;
            }
            else
            {
                node.Next = head;
                tail.Next = node;
                tail = node;
            }
            count++;
        }

        public bool Remove(T data)
        {
            Point<T> current = head;
            Point<T> previous = null;

            if (count == 0) return false;

            do
            {
                if (current.Data.Equals(data))
                {
                    // Если узел в середине или в конце
                    if (previous != null)
                    {
                        // убираем узел current, теперь previous ссылается не на current, а на current.Next
                        previous.Next = current.Next;

                        // Если узел последний,
                        // изменяем переменную tail
                        if (current == tail)
                            tail = previous;
                    }
                    else // если удаляется первый элемент
                    {
                        // если в списке всего один элемент
                        if (count == 1)
                        {
                            head = tail = null;
                        }
                        else
                        {
                            head = current.Next;
                            tail.Next = current.Next;
                        }
                    }
                    count--;
                    return true;
                }
                previous = current;
                current = current.Next;

            } while (current != head);

            return false;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            Point<T> current = head;
            if (current == null) return false;
            do
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            while (current != head);
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Point<T> current = head;
            do
            {
                if (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
            while (current != head);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("\nВведите N: ");

            bool check;
            int N;

            do
            {
                check = Int32.TryParse(Console.ReadLine(), out N);
                if (!check || N < 1) Console.WriteLine("\nНеверный ввод!");
            } while (!check || N < 1);

            CircularLinkedList<int> list = new CircularLinkedList<int>();

            for (int i = 0; i < N; i++)
            {
                list.Add(i + 1);
            }

            Console.Write("\nВведите число для поиска: ");

            int num;

            do
            {
                check = Int32.TryParse(Console.ReadLine(), out num);
                if (!check || num < 1) Console.WriteLine("\nОшибка ввода!");
            } while (!check || num < 1);

            if (list.Contains(num)) Console.WriteLine("\nДанное число есть в списке");
            else Console.WriteLine("\nДанного числа нет в списке");

            Console.Write("\nВведите число для удаления: ");

            int rem;

            do
            {
                check = Int32.TryParse(Console.ReadLine(), out rem);
                if (!check || rem < 1) Console.WriteLine("\nОшибка ввода!");
            } while (!check || rem < 1);

            if (list.Contains(rem)) list.Remove(rem);
            else Console.WriteLine("\nВ списке нет такого элемента!");

            Console.WriteLine("\nСписок: ");
            foreach(int x in list)
            {
                Console.Write("{0}  ", x);
            }

            Console.ReadKey();
        }
        
    }
}
