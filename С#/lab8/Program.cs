using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    class Program
    {
        static void Main(string[] args)
        {

            Task t = Task.Factory.StartNew(MaxValue);
            Console.ReadKey();

        }

        static void MaxValue()
        {
            int[,] massive = new int[5, 5];
            Random rand = new Random();
            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    massive[i, j] = rand.Next(0, 10);
                }
            }
            int maxValue = massive.Cast<int>().Max();
            Console.WriteLine($"Максимальный элемент в матрице: {maxValue}");
        }
    }
}
