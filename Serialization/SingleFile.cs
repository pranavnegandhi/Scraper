using System.IO;

namespace Notadesigner.Scraper.Serialization
{
    public class SingleFile : IFileLayout
    {
        private readonly DirectoryInfo _basePath;

        public SingleFile(string basePath)
        {
            _basePath = new DirectoryInfo(basePath);
            if (!_basePath.Exists)
            {
                _basePath.Create();
            }
        }

        public FileInfo GetPath(string name)
        {
            if (Path.GetExtension(name) == "")
            {
                name = $"{name}.html";
            }

            var filePath = Path.Combine(_basePath.FullName, name);

            var info = new FileInfo(filePath);

            return info;
        }
    }
}