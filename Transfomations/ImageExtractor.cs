namespace Notadesigner.Scraper.Transformations
{
    public class ImageExtractor : ElementExtractor
    {
        private const string _elementName = "img";

        public override string ElementName
        {
            get
            {
                return _elementName;
            }
        }
    }
}