using System.Collections.Generic;
using System.Threading.Tasks;

namespace web5laba
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string pathToTxt = "words.txt";
            List<string> words = await new List<string>().GetOutTxtAsync(pathToTxt); //#Получаем слова
            WebRobber.GetCsvFile("https://www.bukvarix.com/", words);//#Запихиваем, скачиваем Временно выкл, а то бан по ip
            GoogleDriveSendFiles.PushAsync();         
            string path = "";
            List<string> ExtentionsWords = await CsvParser.ParseThisAsync();//#Парсер csv файла
            var uniq = ExtentionsWords.GetUniq();//Проверить на повторы и удалить ключевые слова.
            TxtWriter.TxtWrite(pathToTxt, words, uniq);//Дополнить words.txt
            Cleaner.CleanProjAsync();//Подчищаем за собой
        }
    }
    
}
