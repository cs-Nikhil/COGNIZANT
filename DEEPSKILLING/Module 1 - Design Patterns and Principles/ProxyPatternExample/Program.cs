using ProxyPatternExample.Images;

namespace ProxyPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            IImage image = new ProxyImage("sample.jpg");

            image.Display();

            System.Console.WriteLine();

            image.Display();
        }
    }
}