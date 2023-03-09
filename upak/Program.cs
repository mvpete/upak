// See https://aka.ms/new-console-template for more information

// upak compress -f file1.txt file2.txt ... -d ../rel/path/to C:/full/path/to -o pak.zip

// upak decompress -f ../path/to/pak.zip -o /output/directory

// upak add -f file1.txt -t pak.zip

// upak show -f pak.zip


using upak.core;

try
{

    Arguments parsedArgs = Arguments.Parse(args);
    BasicNamedStreamProvider bsp = new BasicNamedStreamProvider();

    foreach (string file in parsedArgs.InputFiles)
    {
        bsp.AddFileStream(file);
    }

    foreach (string dir in parsedArgs.InputDirectories)
    {
        bsp.AddDirectoryRecursive(dir);
    }


    new CompressionBuilder()
        .AddInputStreamProvider(bsp)
        .SetOutputStream(File.Open(parsedArgs.OutputFile, FileMode.Create))
        .CreateZipArchive();

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
