using System;

namespace lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<Action<string, string>, bool> func = GetTrue; //создание делегата 
            Action<string, string> action = Draw; //инициализация делегата
            func.Invoke(action); //вызов делегата
            func = GetFalse; // инициализация делегата
            func.Invoke(action); //вызов делегата

        }

        static void Draw(string x, string y) //метод вывода на экран
        {
            Console.WriteLine($"{x} and {y}");

        }
        static bool GetTrue(Action<string, string> draw) //true
        {
            draw.Invoke("word", "word2");
            return true;
        }
        static bool GetFalse(Action<string, string> draw) //false
        {
            draw.Invoke("elemination", "word4");
            return false;
        }


    }
}
