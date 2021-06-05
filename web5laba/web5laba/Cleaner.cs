using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace web5laba
{
    public static class Cleaner
    {
        public static async System.Threading.Tasks.Task CleanProjAsync()
        {
            List<string> paths = await new List<string>().GetPaths("");//Пути к csv файлам
            foreach(var i in paths)
            {
                File.Delete(i);
            }
        }
    }
}
