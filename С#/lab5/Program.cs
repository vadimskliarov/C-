using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread[] time = new Thread[5];
            Random rnd = new Random();
            string[] words = { "roflan byldiga", "roflan pomoika", "roflan chelik" };
            {
                for (int i = 0; i < time.Length; i++)
                {
                    time[i] = new Thread(() => StaticString(words[rnd.Next(0, words.Length)]));
                    time[i].Start();
                }

            }
        }
        static void StaticString(string word)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            string answer = "";
            var charLook = word.GroupBy(c => c).Select(c => new { Char = c.Key, Count = c.Count() });
            foreach (var c in charLook)
            {
                answer += ($"{c.Char}-{c.Count}, ");
            }
            Console.WriteLine($"Поток: {threadId}, результат: {answer}");

        }
    }
}
