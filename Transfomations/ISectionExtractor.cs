using System.IO;
using System.Threading.Tasks;
using AngleSharp.Dom;

namespace Notadesigner.Scraper.Transformations
{
    public interface ISectionExtractor
    {
        Task<IElement> ExtractAsync(Stream inputStream, string selector);
    }
}