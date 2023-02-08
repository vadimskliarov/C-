using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab4
{
    public delegate int[,] TakesAWhileDelegate(int row, int col);
    class Program
    {
        static void Main(string[] args)
        {
            TakesAWhileDelegate dl = TakesAWhile;
            dl.BeginInvoke(5, 5, ar =>
            {
                var result = dl.EndInvoke(ar);
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        Console.Write((result[i, j]) + "\t");

                    }
                    Console.WriteLine();
                }

            }, null);
            for (int i = 0; i < 100; i++)
            {
                Console.Write(".");
                Thread.Sleep(50);
            }
        }

        static int[,] TakesAWhile(int row, int col)
        {
            int[,] matrix = new int[row, col];
            Random r = new Random();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = r.Next(0, 2);

                }

            }
            return matrix;
        }
    }
}
