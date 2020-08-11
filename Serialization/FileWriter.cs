using Notadesigner.Scraper.Serialization;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Scraper.Serialization
{
    public class FileWriter
    {
        private readonly IFileLayout _layout;

        public FileWriter(IFileLayout layout)
        {
            _layout = layout;
        }

        public async Task WriteAsync(Stream inputStream, string name)
        {
            try
            {
                var outputPath = _layout.GetPath(name);
                using (var outputStream = File.Create(outputPath.FullName))
                {
                    using (var writer = new StreamWriter(outputStream))
                    {
                        await inputStream.CopyToAsync(outputStream);
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