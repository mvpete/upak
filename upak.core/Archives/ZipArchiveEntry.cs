using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upak.core.Archives
{
    public class ZipArchiveEntry : IArchiveEntry
    {
        private System.IO.Compression.ZipArchiveEntry ThisEntry { get; }

        public ZipArchiveEntry(System.IO.Compression.ZipArchiveEntry entry)
        {
            ThisEntry = entry;
        }

        public void Delete()
        {
            ThisEntry.Delete();
        }

        public Stream Open()
        {
            return ThisEntry.Open();
        }
    }
}
