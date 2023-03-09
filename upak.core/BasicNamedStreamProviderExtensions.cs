using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upak.core
{
    public static class BasicNamedStreamProviderExtensions
    {
        public static BasicNamedStreamProvider AddTextStream(this BasicNamedStreamProvider provider, string name, string text)
        {
            StreamWriter sw = new StreamWriter(new MemoryStream());
            sw.Write(text);
            sw.Flush();
            provider.AddStream(name, sw.BaseStream);
            return provider;
        }

        public static BasicNamedStreamProvider AddFileStream(this BasicNamedStreamProvider provider, string filePath)
        {
            return provider.AddFileStream(Path.GetFileName(filePath), filePath);
        }

        public static BasicNamedStreamProvider AddFileStream(this BasicNamedStreamProvider provider, string archiveName, string filePath)
        {
            if(filePath == null)
                throw new ArgumentNullException(nameof(filePath));

            if(!File.Exists(filePath))
                throw new FileNotFoundException($"File '{filePath}' not found.");

            provider.AddStream(archiveName, File.Open(filePath, FileMode.Open));

            return provider;
        }

        public static BasicNamedStreamProvider AddDirectoryRecursive(this BasicNamedStreamProvider provider, string directoryPath, string archivePath=null)
        {
            if(directoryPath == null)
                throw new ArgumentNullException(nameof(directoryPath));

            FileAttributes attr = File.GetAttributes(directoryPath);
            if(!Directory.Exists(directoryPath) || !attr.IsDirectory())
                throw new DirectoryNotFoundException($"Directory '{directoryPath}' is not a directory.");

            if (archivePath == null)
                archivePath = directoryPath;

            foreach (string filePath in Directory.GetFileSystemEntries(directoryPath))
            {
                attr = File.GetAttributes(filePath);
                string archiveName = filePath.Replace(archivePath + Path.DirectorySeparatorChar, "");
                if (attr.IsDirectory())
                {
                    provider.AddDirectory(archiveName);
                    provider.AddDirectoryRecursive(filePath, archivePath);
                }
                else
                    provider.AddFileStream(archiveName, filePath);
            }
            return provider;
        }

    }
}
