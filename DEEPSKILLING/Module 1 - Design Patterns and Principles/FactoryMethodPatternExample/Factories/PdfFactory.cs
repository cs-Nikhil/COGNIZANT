using FactoryMethodPatternExample.Documents;

namespace FactoryMethodPatternExample.Factories
{
    public class PdfFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new PdfDocument();
        }
    }
}