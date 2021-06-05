using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace web5laba
{
    public static class TxtExtruder
    {

        public static async Task<List<string>> GetOutTxtAsync(this List<string> text, string path)
        {
            List<string> temp = new List<string>();
            
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    temp.Add(line);
                }
            }


            return temp;
        }
    }
}
