using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Birds.ClientModels.Birds;
using Birds.ClientModels.Files;
using Newtonsoft.Json;
using File = System.IO.File;

namespace FilesTool
{
    public static class Loader
    {
        private const string Url = "https://localhost:5001";
        private const string imagesDirectoryPath = "D:\\NSU\\УППРПО\\Images";
        private const string soundsDirectoryPath = "D:\\NSU\\УППРПО\\Sounds";
        private const string birdsData = "bird_data.json";
        
        public static async Task UploadBirdsToServer()
        {
            var batchBuildInfo = JsonConvert.DeserializeObject<BatchBirdsBuildInfo>(File.ReadAllText(birdsData));
            var json = JsonConvert.SerializeObject(batchBuildInfo);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response;

            using (var client = new HttpClient())
            {
                response = await client.PostAsync(Url + "/api/v1/birds", stringContent).ConfigureAwait(false);
            }

            Console.WriteLine(response.StatusCode);
        }

        public static async Task UploadFilesToServer(string directoryPath, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            var dirInfo = new DirectoryInfo(directoryPath);

            foreach (var file in dirInfo.GetFiles())
            {
                var name = file.Name;
                Console.Write(name + "  ");
                var content = System.IO.File.ReadAllBytes(file.FullName);
                var fileId = await CreateFile(name, content, token).ConfigureAwait(false);
                Console.WriteLine(fileId);
            }
        }

        private static async Task<string> CreateFile(string fileName, byte[] content, CancellationToken token)
        {
            var creationInfo = new
            {
                Name = fileName,
                Data = content,
            };

            var json = JsonConvert.SerializeObject(creationInfo);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response;

            using (var client = new HttpClient())
            {
                response = await client.PostAsync(Url + "/api/v1/files", stringContent, token).ConfigureAwait(false);
            }

            var responseStringContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var file = JsonConvert.DeserializeObject<FileCreationResultInfo>(responseStringContent);

            return file.Id;
        }
    }
}