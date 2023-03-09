using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upak.core
{
    public static class FileAttributesExtensions
    {
        public static bool IsDirectory(this FileAttributes attr)
        {
            return (attr & FileAttributes.Directory) == FileAttributes.Directory;
        }

        public static bool IsDirectory(this string path)
        {
            return File.GetAttributes(path).IsDirectory();
        }

    }
}
