using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Notadesigner.Scraper.Serialization
{
    public class HttpRetriever
    {
        private HttpClient _httpClient = new HttpClient();

        public async Task<Stream> StartAsync(Uri uri)
        {
            try
            {
                var result = await _httpClient.GetAsync(uri);
                if (!result.IsSuccessStatusCode)
                {
                    return null;
                }

                var content = result.Content;
                var body = await content.ReadAsStreamAsync();

                return body;
            }
            catch (Exception exception)
            {
                Trace.TraceError(exception.Message);
            }

            return null;
        }
    }
}