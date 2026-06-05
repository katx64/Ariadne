using System.IO;
using System.Linq;

namespace Ariadne.Utils.IO
{
    internal static class Reader
    {
        public static string[] ReadFile(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}