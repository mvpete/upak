using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using upak.core.Archives;

namespace upak.core
{
    public static class ArchiveFactory
    {
        public static IArchive OpenArchive(string archivePath)
        {
            if(string.IsNullOrEmpty(archivePath) || !File.Exists(archivePath))
                throw new ArgumentException(nameof(archivePath));

            string extension = Path.GetExtension(archivePath);
            switch (extension)
            {
                case ".zip":
                    return new ZipArchive(File.Open(archivePath, FileMode.Open), System.IO.Compression.ZipArchiveMode.Read);
                default:
                    break;
            }
            throw new Exception("Invalid archive type.");
        }

        public static IArchive CreateArchive(string archivePath)
        {
            if (string.IsNullOrEmpty(archivePath) || File.Exists(archivePath))
                throw new ArgumentException(nameof(archivePath));

            string extension = Path.GetExtension(archivePath);
            switch (extension)
            {
                case ".zip":
                    return new ZipArchive(File.Open(archivePath, FileMode.CreateNew), System.IO.Compression.ZipArchiveMode.Create);
                default:
                    break;
            }
            throw new Exception("Invalid archive type.");
        }
    }
}
