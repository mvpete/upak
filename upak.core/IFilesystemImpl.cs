using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upak.core
{
    public interface IFilesystemImpl
    {
        void CreateDirectory(string path);
        Stream CreateFile(string path);

        Stream OpenFile(string path, FileMode mode);
    }
}
