using AngleSharp.Dom;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Notadesigner.Scraper.Transformations
{
    public interface IElementExtractor
    {
        string ElementName
        {
            get;
        }

        Task<IElement> ExtractAsync(Stream inputStream, string selector);

        Task<IEnumerable<IElement>> ExtractAllAsync(Stream inputStream, string selector);
    }
}