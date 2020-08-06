using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;

namespace Notadesigner.Scraper.Transformations
{
    public class EntryContentExtractor : ISectionExtractor
    {
        private const string _elementName = "div";

        public async Task<IElement> ExtractAsync(Stream inputStream, string selector = "entry-content")
        {
            var parser = new HtmlParser();
            var document = await parser.ParseDocumentAsync(inputStream);
            var elements = document.All.Where(e => e.LocalName == _elementName && e.ClassList.Contains(selector));
            var first = elements.FirstOrDefault();

            return first;
        }
    }
}