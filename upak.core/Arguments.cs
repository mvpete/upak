﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upak.core
{
    public enum Actions { Compress, Decompress, Add, Show };
    public class Arguments
    {
        public Actions Action { get; set; }
        public List<string> InputFiles { get; } = new List<string>();
        public List<string> InputDirectories { get; } = new List<string>();
        public string OutputFile { get; set; } = string.Empty;


        public static Arguments Parse(string[] args)
        {
            if (args.Length < 4)
                throw new Exception("Bad usage: upak [compress] -f file1 file2 file3 -d dir1 dir2 dir3 -o output.zip");

            Arguments result = new Arguments();

            result.Action = Enum.Parse<Actions>(args[0], true);

            int s = 0;
            for (int i = 1; i < args.Length; ++i)
            {
                string arg = args[i];
                if (arg == "-f")
                {
                    s = 1;
                }
                else if (arg == "-d")
                {
                    s = 2;
                }
                else if (arg == "-o")
                {
                    s = 3;
                }
                else
                {
                    switch (s)
                    {
                        case 1:
                            result.InputFiles.Add(arg);
                            break;
                        case 2:
                            result.InputDirectories.Add(arg);
                            break;
                        case 3:
                            if (!string.IsNullOrEmpty(result.OutputFile))
                                throw new Exception("Bad usage: upak [compress] -f file1 file2 file3 -d dir1 dir2 dir3 -o output.zip");

                            result.OutputFile = arg;
                            break;
                        default:
                            throw new Exception("Bad usage: upak [compress] -f file1 file2 file3 -d dir1 dir2 dir3 -o output.zip");
                    }
                }

            }

            if (string.IsNullOrEmpty(result.OutputFile) || (result.InputFiles.Count == 0 && result.InputDirectories.Count == 0))
                throw new Exception("Bad usage: upak [compress] -f file1 file2 file3 -d dir1 dir2 dir3 -o output.zip");

            return result;

        }

    }
}
