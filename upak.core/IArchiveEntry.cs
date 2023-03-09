using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upak.core
{
    public interface IArchiveEntry
    {
        Stream Open();
        void Delete();
    }
}
