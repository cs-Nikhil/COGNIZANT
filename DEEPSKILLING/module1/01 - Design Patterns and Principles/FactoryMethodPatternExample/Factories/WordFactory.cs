using FactoryMethodPatternExample.Documents;

namespace FactoryMethodPatternExample.Factories
{
    public class WordFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new WordDocument();
        }
    }
}