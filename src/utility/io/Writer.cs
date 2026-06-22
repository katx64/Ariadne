using System;
using System.IO;

namespace Ariadne.Utility.IO
{
    internal sealed class Writer
    {
        private static Writer? _Instance = null;

        private Writer() { }

        public static Writer GetInstance()
        {
            if (_Instance is null)
            {
                Console.WriteLine("[Info]: Creating new Writer instance!");

                _Instance = new Writer();
            }

            return _Instance;
        }

        // TODO: String path maybe useless (Store every file in the same folder!)
        public void WriteFile(char[,] grid, string path)
        {
            
        }
    }
}