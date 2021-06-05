using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace web5laba
{
    public static class TxtWriter
    {
        public static  void TxtWrite(string pathToTxt, List<string> words, IEnumerable<string> uniq)
        {
            string writePath = pathToTxt;


            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    //Console.WriteLine("Part1");
                    foreach (var i in words)
                    {
                        sw.WriteLine(i);
                    }
                    foreach (var i in uniq)
                    {
                        sw.WriteLine(i);
                    }
                    

                }
                
                Console.WriteLine("Запись выполнена");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
