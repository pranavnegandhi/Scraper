using System.IO;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;

namespace Notadesigner.Scraper.Transformations
{
    public static class IBrowsingContextExtensions
    {
        public async static Task<IDocument> CreateDocumentAsync(this IBrowsingContext context, string templateFilePath)
        {
            var reader = new DocumentExtensionsHelper();
            var template = reader.ReadTemplate(templateFilePath);
            var document = await context.OpenAsync(request => request.Content(template));

            return document;
        }
    }

    class DocumentExtensionsHelper
    {
        internal string ReadTemplate(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}