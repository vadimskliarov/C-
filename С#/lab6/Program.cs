using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab6
{

    class Program
    {
        static void Main(string[] args)
        {

            var d = new MyThread("coffee");
            var t2 = new Thread(d.ThreadMain);
            t2.Start();

        }

        public class MyThread
        {
            private string word;
            public MyThread(string word)
            {
                this.word = word;
            }
            public void ThreadMain()
            {
                string answer = "";
                var charLook = word.GroupBy(c => c).Select(c => new { Char = c.Key, Count = c.Count() });
                foreach (var c in charLook)
                {
                    answer += ($"{c.Char}-{c.Count}, ");
                }

                Console.WriteLine(answer);
            }
        }

    }

}
