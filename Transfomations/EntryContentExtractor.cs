namespace Notadesigner.Scraper.Transformations
{
    public class EntryContentExtractor : ElementExtractor
    {
        private const string _elementName = "div";

        public override string ElementName
        {
            get
            {
                return _elementName;
            }
        }
    }
}