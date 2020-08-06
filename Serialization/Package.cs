using System.IO;

namespace Notadesigner.Scraper.Serialization
{
    public class Package : IFileLayout
    {
        private DirectoryInfo _basePath;

        public Package(string basePath)
        {
            _basePath = new DirectoryInfo(basePath);
            if (!_basePath.Exists)
            {
                _basePath.Create();
            }
        }

        public FileInfo GetPath(string name)
        {
            var filePath = Path.Combine(_basePath.FullName, name, "index.html");
            var info = new FileInfo(filePath);
            var dir = info.Directory;
            if (!dir.Exists)
            {
                dir.Create();
            }

            return info;
        }
    }
}