using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upak.core
{
    internal interface IArchive : IDisposable
    {
        Stream CreateEntry(string entryName);
    }
}
