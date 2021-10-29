using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Threading;

namespace Lab22
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Размер массива: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int m = Convert.ToInt32(Console.ReadLine());
            int[,] array = new int[n, m];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    array[i, j] = random.Next(-50, 100);
                    Console.Write("{0,4}", array[i, j]);
                }
                Console.WriteLine();
            }

            Task task1 = new Task(delegate () { Sum(array); });

            Action<Task, object> actionTask2 = new Action<Task, object>(Max);
            Task task2 = task1.ContinueWith(actionTask2, array);

            task1.Start();
            Console.ReadKey();
        }
        static void Max(Task task, object a)
        {
            int[,] c = (int[,])a;
            int max = 0;
            foreach (int b in c)
            {
                if (b > max)
                    max = b;
            }
            Console.WriteLine("Максимальное значение ={0}", max);
        }
        static void Sum(int[,] a)
        {
            int sum = 0;
            foreach (int b in a)
            {
                sum += b;
            }
            Console.WriteLine("Сумма всех элементов ={0}", sum);
        }
    }
}
