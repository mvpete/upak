using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upak.core
{
    public class NamedStream
    {
        public string Name { get; set; } = string.Empty;
        public Stream? Stream { get; set; }
    }
}
