// See https://aka.ms/new-console-template for more information

// upak compress -f file1.txt file2.txt ... -d ../rel/path/to C:/full/path/to -o pak.zip

// upak decompress -f ../path/to/pak.zip -o /output/directory

// upak add -f file1.txt -t pak.zip

// upak show -f pak.zip


using upak.core;

try
{
    Arguments parsedArgs = Arguments.Parse(args);
    switch (parsedArgs.Action)
    {
        case Actions.Compress:
            Compress(parsedArgs);
            break;
        case Actions.Decompress:
            Decompress(parsedArgs);
            break;
        default:
            throw new Exception("Unknown action.");
    }

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}


void Compress(Arguments args)
{
    BasicNamedStreamProvider bsp = new BasicNamedStreamProvider();

    foreach (string file in args.InputFiles)
    {
        bsp.AddFileStream(file);
    }

    foreach (string dir in args.InputDirectories)
    {
        bsp.AddDirectoryRecursive(dir);
    }
    new CompressionBuilder()
               .AddInputStreamProvider(bsp)
               .CreateArchive(args.Output);
}

void Decompress(Arguments args)
{
    Decompressor.DecompressArchive(args.Input, args.Output);
}