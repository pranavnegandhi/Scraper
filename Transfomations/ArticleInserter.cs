using AngleSharp.Dom;

namespace Notadesigner.Scraper.Transformations
{
    public class ArticleInserter
    {
        public INode Replace(INode placeholder, IElement element)
        {
            placeholder.InsertAfter(element);
            placeholder.RemoveFromParent();

            return placeholder;
        }
    }
}