using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Html;

namespace Notadesigner.Scraper.Serialization
{
    public class HtmlWriter
    {
        private IFileLayout _layout;

        public HtmlWriter(IFileLayout layout)
        {
            _layout = layout;
        }

        public async Task WriteAsync(IDocument document, string name)
        {
            try
            {
                var outputPath = _layout.GetPath(name);
                var formatter = new MinifyMarkupFormatter();
                using (var outputStream = File.Create(outputPath.FullName))
                {
                    using (var writer = new StreamWriter(outputStream))
                    {
                        document.ToHtml(writer, formatter);
                        await writer.FlushAsync();
                    }
                }
            }
            catch (Exception exception)
            {
                Trace.TraceError(exception.Message);
            }
        }
    }
}