
using System.Collections.Generic;
using System.IO;

namespace web5laba
{
    public static class CsvParser
    {
        public static async System.Threading.Tasks.Task<List<string>> ParseThisAsync()
        {

            List<string> paths = await new List<string>().GetPaths("");//Пути к csv файлам
            List<string> listA = new List<string>();//Слова
            foreach (var i in paths)
            {
                using (var reader = new StreamReader(i))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');
                        listA.Add(values[0].Substring(1, values[0].Length - 2));
                        //Console.WriteLine(values[0].Substring(1, values[0].Length - 2));
                    }
                }
            }            
            return listA;
        }
    }
}
