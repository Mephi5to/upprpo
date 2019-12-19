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
        public static TestCaseData[] CorrectRequestDataSource { get; } =
        {
            new TestCaseData(new BatchBirdsBuildInfo { Items = new List<ClientModels.BirdBuildInfo>()
            {
                new ClientModels.BirdBuildInfo { Name = "Рябчик", Description = "Описание рябчика" },
                new ClientModels.BirdBuildInfo { Name = "Зяблик", Description = "Описание зяблика" },
            },
            })
        };

        // public static TestCaseData[] RequestTypesSource { get; } = new[]
        // {
        // };
        //
        // public static TestCaseData[] CorrectResultSource { get; } =
        // {
        // };
        //
        // public static TestCaseData[] SetResultToUnknownRequestTestSource { get; } =
        // {
        // };
        //
        // public static TestCaseData[] SetResultWithResultPayloadOtherTypeTestSource { get; } =
        // {
        //     new TestCaseData(RequestType.Guarantee, RequestType.GuaranteeLine, new GuaranteeData(), new GuaranteeLineResultPayload(1, new GuaranteeLineOption[0])),
        //     new TestCaseData(RequestType.GuaranteeLine, RequestType.Guarantee, new GuaranteeLineData(), new GuaranteeResultPayload(new GuaranteeOption[0], null, null))
        // };
        //
        // public static TestCaseData[] DoubleSetResultTestSource { get; } = new[]
        // {
        //     new TestCaseData(RequestType.Guarantee, new GuaranteeData(), new GuaranteeResultPayload(new GuaranteeOption[0], null, null)),
        //     new TestCaseData(RequestType.GuaranteeLine, new GuaranteeLineData(), new GuaranteeLineResultPayload(1, new GuaranteeLineOption[0]))
        // };
        //
        // public static TestCaseData[] SearchTestsSource { get; } = new[]
        // {
        //     new TestCaseData(
        //         4,
        //         new[] { RequestType.Guarantee, RequestType.Guarantee, RequestType.GuaranteeLine, RequestType.GuaranteeLine },
        //         new IRequestData[] { new GuaranteeData(), new GuaranteeData(), new GuaranteeLineData(), new GuaranteeLineData() },
        //         new IRequestResultPayload[] { null, new GuaranteeResultPayload(new GuaranteeOption[0], null, null), null, new GuaranteeLineResultPayload(1, new GuaranteeLineOption[0]) })
        // };
        //
        // public static TestCaseData[] RejectTestSource { get; } = new[]
        // {
        //     new TestCaseData(RequestType.Guarantee, new GuaranteeData(), "someReason"),
        //     new TestCaseData(RequestType.GuaranteeLine, new GuaranteeLineData(), "someReason"),
        // };
        //
        // public static TestCaseData[] CancelTestSource { get; } = new[]
        // {
        //     new TestCaseData(RequestType.Guarantee, new GuaranteeData()),
        //     new TestCaseData(RequestType.GuaranteeLine, new GuaranteeLineData()),
        // };

        protected BirdsRepository BirdsRepository { get; set; }
        protected FilesRepository FilesRepository { get; set; }
        protected BirdsApiClient BirdsApiClient { get; set; }

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
