using AngleSharp;
using AngleSharp.Html.Dom;
using Notadesigner.Scraper.Serialization;
using Notadesigner.Scraper.Transformations;
using Scraper.Serialization;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Notadesigner.Scraper
{
    class Program
    {
        private static readonly IReadOnlyDictionary<string, IFileLayout> _modeMap = new Dictionary<string, IFileLayout>()
        {
            { "single", new SingleFile("..\\output\\")},
            { "package", new Package("..\\output\\")},
            { "nested", new NestedFile("..\\output\\") }
        };

        public async static Task<int> Main(string[] args)
        {
            var listener = new ConsoleTraceListener();
            Trace.Listeners.Add(listener);

            var rootCommand = new RootCommand();
            rootCommand.AddOption(
                new Option("--mode", "The structure of the output. Valid values are single or package.")
                {
                    Argument = new Argument<string>()
                });
            rootCommand.AddOption(
                new Option("--uri", "The URL of the initial RSS or Atom feed.")
                {
                    Argument = new Argument<Uri>()
                });

            rootCommand.Handler = CommandHandler.Create<string, Uri>(Handler);

            return await rootCommand.InvokeAsync(args);
        }

        private async static Task Handler(string mode, Uri uri)
        {
            IFileLayout docLayout;
            if (!_modeMap.TryGetValue(mode, out docLayout))
            {
                throw new ArgumentException($"The value of {nameof(mode)} should be single or package.");
            }

            var mapper = new FeedRetriever(uri);
            await mapper.ReadAsync();

            Trace.TraceInformation($"Retrieved {mapper.Count} links.");

            var retriever = new HttpRetriever();
            var article = new ArticleExtractor();
            var images = new ImageExtractor();
            var context = BrowsingContext.New(Configuration.Default);
            var inserter = new ArticleInserter();
            var imgWriter = new FileWriter(_modeMap["nested"]);
            var docWriter = new HtmlWriter(docLayout);
            string fileName;

            foreach (var i in mapper)
            {
                Trace.TraceInformation($"{i.Title}\t{i.Link}");

                var itemUri = new Uri(i.Link);
                var input = await retriever.StartAsync(itemUri);
                var content = await article.ExtractAsync(input, "type-post");
                var imgs = await images.ExtractAllAsync(input);
                foreach (var j in imgs)
                {
                    var source = ((IHtmlImageElement)j)?.Source ?? "http://127.0.0.1";
                    var imgUri = new Uri(source);
                    var file = await retriever.StartAsync(imgUri);

                    await imgWriter.WriteAsync(file, imgUri.LocalPath);

                    Trace.TraceInformation($"Path: {imgUri.AbsoluteUri} Length: {file.Length}");
                }

                var document = await context.CreateDocumentAsync("templates\\post.html");
                var placeholder = document.QuerySelector("div#article-placeholder");
                inserter.Replace(placeholder, content);

                fileName = itemUri.Segments[1];
                fileName = fileName.Replace("/", "");

                await docWriter.WriteAsync(document, fileName);
            }
        }
    }
}