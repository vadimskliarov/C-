using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab7
{
    public class MassItem
    {
        public int item;
    }
    public class MassData
    {
        private MassItem[,] massive;

        public MassData()
        {
            massive = new MassItem[50, 50];
        }

        public void Add(MassItem newElement)
        {
            bool flag = true;
            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    if (massive[i, j] == null && flag)
                    {
                        flag = false;
                        massive[i, j] = newElement;
                        ThreadPool.QueueUserWorkItem(MethodForThread, newElement.item);
                        break;
                    }
                }
                if (!flag)
                {
                    flag = true;
                    break;
                }

            }

        }
        protected static void MethodForThread(object ob)
        {
            int item = (int)ob;
            Thread.Sleep(10);
            Console.WriteLine("Поток {0}. В матрицу добавлен новый элемент {1}",
                Thread.CurrentThread.ManagedThreadId,
                item);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int maxWorkThread;
            int MaxIOTread;
            ThreadPool.GetMaxThreads(out maxWorkThread, out MaxIOTread);
            Console.WriteLine("Максимально количество рабочих потоков: {0}." +
               "Максимальное количество потоков ввода-вывода {1}",
               maxWorkThread, MaxIOTread);

            MassData myData = new MassData();
            Random rand = new Random();
            for (int i = 0; i < 3000; i++)
            {
                myData.Add(new MassItem() { item = rand.Next(0, 2) });
            }
        }
    }
}
