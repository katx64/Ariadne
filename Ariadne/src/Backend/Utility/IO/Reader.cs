using System;
using System.IO;

namespace Ariadne.Utility.IO
{
    internal sealed class Reader
    {
        private static Reader? _Instance = null;

        private Reader() { }

        public static Reader GetInstance()
        {
            if (_Instance is null)
            {
                Console.WriteLine("[Info]: Creating new Reader instance!");

                _Instance = new Reader();
            }

            return _Instance;
        }

        public string[] ReadFile(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}