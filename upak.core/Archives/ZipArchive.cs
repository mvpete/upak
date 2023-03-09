using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upak.core.Archives
{
    public class ZipArchive : IArchive
    {
        public System.IO.Compression.ZipArchive ThisArchive { get; }


        public ZipArchive(Stream archive, System.IO.Compression.ZipArchiveMode mode)
        {
            ThisArchive = new System.IO.Compression.ZipArchive(archive, mode);
        }

        public IReadOnlyCollection<IArchiveEntry> Entries => ThisArchive.Entries.Select(e => new ZipArchiveEntry(e)).ToList();

        public IArchiveEntry CreateEntry(string entryName)
        {
            return new ZipArchiveEntry(ThisArchive.CreateEntry(entryName));
        }

        public void Dispose()
        {
            this.ThisArchive?.Dispose();
        }

        public IArchiveEntry? GetEntry(string name)
        {
            var e = ThisArchive.GetEntry(name);
            return e == null ? null : new ZipArchiveEntry(e);
        }


    }
}
