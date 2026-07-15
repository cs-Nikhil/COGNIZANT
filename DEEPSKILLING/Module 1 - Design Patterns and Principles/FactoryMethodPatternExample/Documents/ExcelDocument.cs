using System;

namespace FactoryMethodPatternExample.Documents
{
    public class ExcelDocument : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Opening Excel Document");
        }
    }
}