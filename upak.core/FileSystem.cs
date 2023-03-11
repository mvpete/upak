using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upak.core
{
    public static class FileSystem
    {
        public static IFilesystemImpl Instance { get; set; } = new Win32FilesystemImpl();

        public static void CreateDirectory(string path)
        {
           Instance.CreateDirectory(path);
        }

        public static Stream CreateFile(string path)
        {
            return Instance.CreateFile(path);
        }

        public static Stream OpenFile(string path, FileMode mode)
        {
            return Instance.OpenFile(path, mode);
        }
    }

    internal class Win32FilesystemImpl : IFilesystemImpl
    {
        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        public Stream CreateFile(string path)
        {
            return File.Create(path);
        }

        public Stream OpenFile(string path, FileMode mode)
        {
            return File.Open(path, mode);
        }
    }
}
