using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upak.core
{
    public enum CompressionHint { Zip };
    public class Decompressor
    {
        public Decompressor(Stream archive, CompressionHint hint)
        {
        }

        public void SetOutputPath(string outputPath)
        {
        }

        public void Decompress()
        {
           
        }
    }
}
