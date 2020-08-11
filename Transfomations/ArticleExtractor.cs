namespace Notadesigner.Scraper.Transformations
{
    public class ArticleExtractor : ElementExtractor
    {
        private const string _elementName = "article";

        public override string ElementName
        {
            get
            {
                return _elementName;
            }
        }
    }
}