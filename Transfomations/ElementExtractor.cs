using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Notadesigner.Scraper.Transformations
{
    public abstract class ElementExtractor : IElementExtractor
    {
        public abstract string ElementName
        {
            get;
        }

        public async Task<IElement> ExtractAsync(Stream inputStream, string selector = "")
        {
            var elements = await ExtractAllAsync(inputStream, selector);
            var first = elements.FirstOrDefault();

            return first;
        }

        public async Task<IEnumerable<IElement>> ExtractAllAsync(Stream inputStream, string selector = "")
        {
            inputStream.Seek(0, SeekOrigin.Begin);

            var parser = new HtmlParser();
            var document = await parser.ParseDocumentAsync(inputStream);

            var elements = document.All.Where(e => e.LocalName == ElementName);
            if (selector != string.Empty)
            {
                elements = elements.Where(e => e.ClassList.Contains(selector));
            }

            return elements;
        }

        private List<INode> _flatList;

        private IEnumerable<INode> Flatten(INode node, string localName)
        {
            _flatList = new List<INode>();
            WalkInternal(node, localName);

            return _flatList;
        }

        private void WalkInternal(INode node, string localName)
        {
            if (!node.HasChildNodes)
            {
                return;
            }

            foreach (var e in node.ChildNodes)
            {
                if (e is IElement && ((IElement)e)?.LocalName == localName)
                {
                    _flatList.Add(e);
                }

                WalkInternal(e, localName);
            }
        }
    }
}
