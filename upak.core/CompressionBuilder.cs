using System.IO.Compression;

namespace upak.core
{
    public class CompressionBuilder
    {
        private List<IStreamProvider> InputStreamProviders { get; } = new List<IStreamProvider>();

        public CompressionBuilder AddInputStreamProvider(IStreamProvider streamProvider)
        {
            InputStreamProviders.Add(streamProvider);
            return this;
        }

        public CompressionBuilder AddGZipCompression()
        {
            return this;
        }

        public void CreateArchive(string archivePath)
        {
            if (string.IsNullOrEmpty(archivePath) || File.Exists(archivePath))
                throw new ArgumentException(nameof(archivePath));

            string extension = Path.GetExtension(archivePath);
            CreateArchive(extension, FileSystem.OpenFile(archivePath, FileMode.Open));
        }

        public void CreateArchive(string extension, Stream archiveStream)
        {
            using (IArchive archive = ArchiveFactory.CreateArchive(extension, archiveStream))
            {
                foreach (var streamProvider in InputStreamProviders)
                {
                    var next = streamProvider.GetNextStream();
                    while (next != null)
                    {
                        var archiveEntry = archive.CreateEntry(next.Name);
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