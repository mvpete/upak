using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upak.core
{
    public enum CompressionHint { Zip };
    public static class Decompressor
    {
        public static void DecompressArchive(string archivePath, string outputPath)
        {
            Directory.CreateDirectory(outputPath);
            using (IArchive archive = ArchiveFactory.OpenArchive(archivePath))
            {
                foreach (IArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(Path.DirectorySeparatorChar))
                    {
                        // Create a directory
                        FileSystem.CreateDirectory(Path.Combine(outputPath, entry.FullName));
                    }
                    else
                    {
                        // Create a file.
                        var file = FileSystem.CreateFile(Path.Combine(outputPath, entry.FullName));
                        var archiveFile = entry.Open();
                        archiveFile.CopyTo(file);
                    }
                }
            }
        }
       
    }
}
