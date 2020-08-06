using System.IO;

namespace Notadesigner.Scraper.Serialization
{
    public interface IFileLayout
    {
        FileInfo GetPath(string name);
    }
}