using System;
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
                    return new ZipArchive(FileSystem.OpenFile(archivePath, FileMode.Open), System.IO.Compression.ZipArchiveMode.Read);
                default:
                    break;
            }
            throw new Exception("Invalid archive type.");
        }

        public static IArchive CreateArchive(string extension, Stream outputStream)
        {
            
            switch (extension)
            {
                case ".zip":
                    return new ZipArchive(outputStream, System.IO.Compression.ZipArchiveMode.Create);
                default:
                    break;
            }
            throw new Exception("Invalid archive type.");
        }
    }
}
