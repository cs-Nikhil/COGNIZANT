using System;
using System.Collections.Generic;

namespace MagicFilesLib
{
    public interface IDirectoryReader
    {
        IEnumerable<string> GetFiles(string path);
    }

    public class DirectoryExplorer
    {
        private readonly IDirectoryReader _directoryReader;

        public DirectoryExplorer(IDirectoryReader directoryReader)
        {
            _directoryReader = directoryReader;
        }

        public IEnumerable<string> GetFiles(string path)
        {
            return _directoryReader.GetFiles(path);
        }
    }
}
