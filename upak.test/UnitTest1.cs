using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.IO.Compression;
using upak.core;

namespace upak.core.test
{
    [TestClass]
    public class TestCompressionBuilder
    {
        [TestMethod]
        public void TestSimpleZipArchive()
        {
            // Arrange
            BasicNamedStreamProvider provider = new BasicNamedStreamProvider();
            provider
                .AddTextStream("foo.txt", "Foo Foo Foo Foo")
                .AddTextStream("bar.txt", "Bar bar bar bar");

            // Act
            var archiveStream = new MemoryStream();
            CompressionBuilder builder = new CompressionBuilder();
            builder
                .AddInputStreamProvider(provider)
                .SetOutputStream(archiveStream)
                .CreateZipArchive();

            // Assert
            using (ZipArchive za = new ZipArchive(new MemoryStream(archiveStream.GetBuffer())))
            {
                Assert.AreEqual(2, za.Entries.Count);
            }
        }
    }
}