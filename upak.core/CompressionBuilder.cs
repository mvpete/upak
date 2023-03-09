using System.IO.Compression;

namespace upak.core
{
    public class CompressionBuilder
    {
        private List<IStreamProvider> InputStreamProviders { get; } = new List<IStreamProvider>();
        private Stream OutputStream { get; set; }

        public CompressionBuilder AddInputStreamProvider(IStreamProvider streamProvider)
        {
            InputStreamProviders.Add(streamProvider);
            return this;
        }

        public CompressionBuilder SetOutputStream(Stream output)
        {
            OutputStream = output;
            return this;
        }

        public CompressionBuilder AddGZipCompression()
        {
            return this;
        }

        public void CreateZipArchive()
        {
            if (OutputStream == null)
                throw new InvalidOperationException("No output stream specified.");

            using (ZipArchive archive = new ZipArchive(OutputStream, ZipArchiveMode.Create))
            {
                foreach (var streamProvider in InputStreamProviders)
                {
                    var next = streamProvider.GetNextStream();
                    while (next != null)
                    {
                        var archiveEntry = archive.CreateEntry(next.Name, CompressionLevel.SmallestSize);
                        if (next.Stream != null)
                        {
                            using (var zipStream = archiveEntry.Open())
                            {
                                next.Stream.CopyTo(zipStream);
                            }
                        }
                        next = streamProvider.GetNextStream();
                    }
                }
            }
        }
    }
}