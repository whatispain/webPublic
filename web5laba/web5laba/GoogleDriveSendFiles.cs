using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using File = Google.Apis.Drive.v3.Data.File;

namespace web5laba
{
    //Лютая хуета, фу, фу, фу
    public class GoogleDriveSendFiles
    {
        private static string[] Scopes = { DriveService.Scope.Drive };
        private static string ApplicationName = "Web5Lab";
        private static string FolderId = "1BfzST0s7o82Ot7sVvetZqttov9Pxq3hx";
        //private static string _fileName = "testFile1.csv";//Название итоговое файла
        //private static string _filepath = "зависимость.csv";//Путь к файлу
        private static string _contentType = "application/csv";//Тип файла

        public static async System.Threading.Tasks.Task PushAsync()
        {
            UserCredential credential = GetUserCredential();
            DriveService service = GetDriveService(credential);

            List<string> paths = await new List<string>().GetPaths("");//Пути к csv файлам
            foreach (var i in paths)
            {
                UploadFile(service, i, i, _contentType);
            }
            //UploadFile(service, _fileName, _filepath, _contentType);

        }
        private static UserCredential GetUserCredential()
        {
            using(var stream = new FileStream("client_secret.json",FileMode.Open,FileAccess.Read))
            {
                string creadPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                creadPath = Path.Combine(creadPath, "driveApiCredentials", "drive-credentials.json");

                return GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets, 
                    Scopes, 
                    "User",
                    CancellationToken.None,
                    new FileDataStore(creadPath, true)).Result;

            }

        }
        private static DriveService GetDriveService(UserCredential credential)
        {
            return new DriveService(
                new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName
                });
        }
        private static string UploadFile(DriveService service, string fileName, string filePath, string contentType)
        {
            var fileMetadata = new File();
            fileMetadata.Name = fileName;
            fileMetadata.Parents = new List<string> { FolderId };

            FilesResource.CreateMediaUpload request;

            using(var stream = new FileStream(filePath, FileMode.Open))
            {
                request = service.Files.Create(fileMetadata, stream, contentType);
                request.Upload();
            }
            var file = request.ResponseBody;
            return file.Id;
        }
    }
}
