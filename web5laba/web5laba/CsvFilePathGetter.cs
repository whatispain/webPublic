using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace web5laba
{
    public static class CsvFilePathGetter
    {
        public static async Task<List<string>> GetPaths(this List<string> paths, string PathToFolder)
        {
            string[] allfiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "*csv");
            foreach (string filename in allfiles)
            {
                FileInfo test = new FileInfo(filename);
                paths.Add(test.Name);
            }
            return paths;
        }
    }
}
