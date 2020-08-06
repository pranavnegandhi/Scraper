using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Notadesigner.Scraper.Models;

namespace Notadesigner.Scraper.Serialization
{
    public class FeedRetriever : IEnumerable<Item>
    {
        private HttpClient _client = new HttpClient();

        private Uri _baseUri;

        private Rss _feed;

        public FeedRetriever(Uri baseUri)
        {
            _baseUri = baseUri;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _feed.Channel[0].Items.GetEnumerator();
        }

        public IEnumerator<Item> GetEnumerator()
        {
            foreach (var i in _feed.Channel[0].Items)
            {
                yield return i;
            }
        }

        public int Count
        {
            get
            {
                return _feed.Channel[0].Items.Length;
            }
        }

        public async Task ReadAsync()
        {
            try
            {
                var result = await _client.GetAsync(_baseUri.AbsoluteUri);
                if (!result.IsSuccessStatusCode)
                {
                    return;
                }

                var content = result.Content;
                var body = await content.ReadAsStreamAsync();

                var serializer = new XmlSerializer(typeof(Rss));
                _feed = (Rss)serializer.Deserialize(new XmlTextReader(body));
            }
            catch (Exception exception)
            {
                Trace.TraceError(exception.Message);
            }
        }
    }
}