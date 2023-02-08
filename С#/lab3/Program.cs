using System;
using System.Linq;
using System.Threading;

namespace lab3
{
        public delegate string CharCounter(string word, int ms);
        class Program
        {
            static void Main(string[] args)
            {

                CharCounter take = new CharCounter(StaticString);

                IAsyncResult ar = take.BeginInvoke("roflan buldiga", 3000, null, null);

                while (true)
                {
                    Console.Write(".");
                    if (ar.AsyncWaitHandle.WaitOne(40, false))
                    {
                        Console.WriteLine("Результат можно извлечь");
                        break;
                    }

                }

                string result = take.EndInvoke(ar);

                Console.WriteLine("{0}", result);

            }

            static string StaticString(string word, int ms)
            {
                string answer = "";
                var charLook = word.GroupBy(c => c).Select(c => new { Char = c.Key, Count = c.Count() });
                foreach (var c in charLook)
                {
                    answer += ($"{c.Char}-{c.Count}, ");
                }
                Thread.Sleep(ms);
                Console.WriteLine();
                return answer;

            }

        }
}
