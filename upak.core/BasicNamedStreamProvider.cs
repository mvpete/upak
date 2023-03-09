using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upak.core
{
    public class BasicNamedStreamProvider : IStreamProvider
    {
        private int Index = 0;
        private List<NamedStream> Streams { get; } = new List<NamedStream>();

        public void AddDirectory(string name)
        {
            Streams.Add(new NamedStream() {  Name = name.EnsureEndsWith(Path.DirectorySeparatorChar) });
        }
        public void AddStream(string name, Stream stream)
        {
            Streams.Add(new NamedStream() {  Name=name, Stream=stream });
        }

        public NamedStream? GetNextStream()
        {
            if (Index >= 0 && Index < Streams.Count)
            {
                return Streams[Index++];
            }
            return null;
        }

        public void Reset()
        {
            Index = 0;
        }
    }
}
