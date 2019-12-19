using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Birds.ClientModels.Birds;
using Birds.Models.Birds;
using NUnit.Framework;

namespace Tests.BirdsTests
{
    [TestFixture]
    public sealed class CreateTests : TestBase
    {
        [Test]
        [TestCaseSource(typeof(TestBase), nameof(TestBase.CorrectRequestDataSource))]
        public async Task CreateTestAsync(BatchBirdsBuildInfo batchBirdsBuildInfo)
        {
            var result = await this.BirdsApiClient.CreateBatchBirdsAsync(batchBirdsBuildInfo, CancellationToken.None).ConfigureAwait(false);

            Assert.NotNull(result);
            Assert.IsNotEmpty(result.Birds);
        }

        // [Test]
        // public void CreateByNullTest()
        // {
        //     AsyncTestDelegate asyncDelegate = async () => await this.RequestRepository.CreateAsync(null).ConfigureAwait(false);
        //     Assert.ThrowsAsync<ArgumentNullException>(asyncDelegate);
        // }
        //
        // [Test]
        // public void CreateByUnknownRequestTypeTest()
        // {
        //     var requestData = new TestRequestData { OrganizationName = "test" };
        //     var serviceName = "testservice";
        //     var creationInfo = new RequestCreationInfo(Guid.NewGuid(), Guid.NewGuid(), RequestType.Unknown, requestData, serviceName, null, null, null);
        //
        //     AsyncTestDelegate asyncDelegate = async () => await this.RequestRepository.CreateAsync(creationInfo).ConfigureAwait(false);
        //     Assert.ThrowsAsync<InvalidOperationException>(asyncDelegate);
        // }
        //
        // [Test]
        // [TestCaseSource(typeof(TestBase), nameof(TestBase.RequestTypesSource))]
        // public void CreateWithOtherDataTest(RequestType requestType)
        // {
        //     var requestData = new TestRequestData { OrganizationName = "test" };
        //     var serviceName = "testservice";
        //     var creationInfo = new RequestCreationInfo(Guid.NewGuid(), Guid.NewGuid(), requestType, requestData, serviceName, null, null, null);
        //
        //     AsyncTestDelegate asyncDelegate = async () => await this.RequestRepository.CreateAsync(creationInfo).ConfigureAwait(false);
        //     Assert.ThrowsAsync<InvalidCastException>(asyncDelegate);
        // }
        //
        // [Test]
        // [TestCaseSource(typeof(TestBase), nameof(TestBase.RequestTypesSource))]
        // public void CreateTestByCancelledTokenTest(RequestType requestType)
        // {
        //     var requestData = new TestRequestData { OrganizationName = "test" };
        //     var serviceName = "testservice";
        //     var creationInfo = new RequestCreationInfo(Guid.NewGuid(), Guid.NewGuid(), requestType, requestData, serviceName, null, null, null);
        //
        //     AsyncTestDelegate asyncDelegate = async () => await this.RequestRepository.CreateAsync(creationInfo, new CancellationToken(true)).ConfigureAwait(false);
        //     Assert.ThrowsAsync<TaskCanceledException>(asyncDelegate);
        // }
    }
}
