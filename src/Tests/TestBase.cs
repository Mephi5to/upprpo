 using System.Collections.Generic;
 using Birds.ClientModels.Birds;
 using Birds.Models;
 using Birds.Models.Birds.Repository;
 using Birds.Models.Files.Repository;
 using Client;
 using NUnit.Framework;
 using ClientModels = Birds.ClientModels.Birds;

 namespace Tests
{
    public class TestBase
    {
        public static TestCaseData[] CorrectBirdsDataSource { get; } =
        {
            new TestCaseData(new BatchBirdsBuildInfo { Items = new List<ClientModels.BirdBuildInfo>()
            {
                new ClientModels.BirdBuildInfo { Name = "Рябчик", Description = "Описание рябчика" },
                new ClientModels.BirdBuildInfo { Name = "Зяблик", Description = "Описание зяблика" },
            },
            })
        };
        
        public static TestCaseData[] CorrectFilesDataSource { get; } =
        {
            new TestCaseData("D:\\NSU\\УППРПО\\Images\\Деряба.jpg")
        };

        public static TestCaseData[] GetFilesDataSource { get; } =
        {
            new TestCaseData("5dfbbc085a63c91e7c950b8d")
        };
        
        protected IBirdsRepository BirdsRepository { get; set; }
        protected IFilesRepository FilesRepository { get; set; }
        protected IBirdsApiClient BirdsApiClient { get; set; }

        [OneTimeSetUp]
        public void Initialize()
        {
            var configuration = new Configuration();
            this.BirdsRepository = new BirdsRepository(configuration);
            this.FilesRepository = new FilesRepository(configuration);
            this.BirdsApiClient = new BirdsApiClient();
        }
    }
}
