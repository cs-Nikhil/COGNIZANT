using FactoryMethodPatternExample.Documents;

namespace FactoryMethodPatternExample.Factories
{
    public class ExcelFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new ExcelDocument();
        }
    }
}