using Notadesigner.Scraper.Serialization;
using System.IO;

namespace Scraper.Serialization
{
    class NestedFile : IFileLayout
    {
        private readonly DirectoryInfo _basePath;

        public NestedFile(string basePath)
        {
            _basePath = new DirectoryInfo(basePath);
            if (!_basePath.Exists)
            {
                _basePath.Create();
            }
        }

        public FileInfo GetPath(string name)
        {
            var fileName = Path.GetFileName(name);
            var relativePath = Path.GetDirectoryName(name).Trim(Path.DirectorySeparatorChar);
            var filePath = Path.Combine(_basePath.FullName, relativePath, fileName);
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
