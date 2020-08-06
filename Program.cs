using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Diagnostics;
using System.Threading.Tasks;
using AngleSharp;
using Notadesigner.Scraper.Serialization;
using Notadesigner.Scraper.Transformations;

namespace Notadesigner.Scraper
{
    class Program
    {
        private static readonly IReadOnlyDictionary<string, IFileLayout> _modeMap = new Dictionary<string, IFileLayout>()
        {
            { "single", new SingleFile("..\\output\\")},
            { "package", new Package("..\\output\\")}
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
            IFileLayout layout;
            if (!_modeMap.TryGetValue(mode, out layout))
            {
                throw new ArgumentException($"The value of {nameof(mode)} should be single or package.");
            }

            var mapper = new FeedRetriever(uri);
            await mapper.ReadAsync();

            Trace.TraceInformation($"Retrieved {mapper.Count} links.");

            var retriever = new ItemRetriever();
            var extractor = new ArticleExtractor();
            var context = BrowsingContext.New(Configuration.Default);
            var inserter = new ArticleInserter();
            var writer = new HtmlWriter(layout);

            foreach (var i in mapper)
            {
                Trace.TraceInformation($"{i.Title}\t{i.Link}");

                var u = new Uri(i.Link);
                var input = await retriever.StartAsync(u);
                var content = await extractor.ExtractAsync(input);
                var document = await context.CreateDocumentAsync("templates\\post.html");
                var placeholder = document.QuerySelector("div#article-placeholder");
                inserter.Replace(placeholder, content);

                var fileName = u.Segments[1];
                fileName = fileName.Replace("/", "");

                await writer.WriteAsync(document, fileName);
            }
        }
    }
}