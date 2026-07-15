using System;

namespace SingletonPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger1 = Logger.GetInstance();
            logger1.Log("Application Started");

            Logger logger2 = Logger.GetInstance();
            logger2.Log("Processing Request");

            if (logger1 == logger2)
            {
                Console.WriteLine("Singleton Pattern Verified: Only one instance exists.");
            }
            else
            {
                Console.WriteLine("Multiple instances exist.");
            }
        }
    }
}