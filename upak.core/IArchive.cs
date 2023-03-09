using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upak.core
{
    public interface IArchive : IDisposable
    {
        IReadOnlyCollection<IArchiveEntry> Entries { get; }
        IArchiveEntry CreateEntry(string entryName);
        IArchiveEntry? GetEntry(string name);
    }
}
