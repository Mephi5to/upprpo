using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Birds.API.Converters;
using Birds.API.Errors;
using Birds.ClientModels.Birds;
using Birds.Models.Birds.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Birds.API.Controllers
{
    [Route("api/v1/birds")]
    public sealed class BirdsController : ControllerBase
    {
        private readonly IBirdsRepository birdsRepository;

        public BirdsController(IBirdsRepository birdsRepository)
        {
            this.birdsRepository = birdsRepository ?? throw new ArgumentNullException(nameof(birdsRepository));
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateBatchAsync(
            [FromBody] BatchBirdsBuildInfo batchBuildInfo,
            CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            if (batchBuildInfo == null)
            {
                var error = ServiceErrorResponses.BodyIsMissing("BatchBirdsBuildInfo");
                return this.BadRequest(error);
            }

            var modelBatchBuildInfo = batchBuildInfo.Items.Select(BirdsConverter.Convert).ToList();
            var modelBirds = await this.birdsRepository.CreateBatchAsync(modelBatchBuildInfo, token).ConfigureAwait(false);

            var viewBirdList = new BirdsList
            {
                Birds = modelBirds.Select(BirdsConverter.Convert).ToList(),
            };
            
            return this.Ok(viewBirdList);
        }

        [HttpGet]
        public async Task<IActionResult> SearchAsync(
            [FromQuery] BirdsSearchQuery searchQuery,
            CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            var modelSearchQuery = BirdsConverter.Convert(searchQuery);
            var modelBirds = await this.birdsRepository.SearchAsync(modelSearchQuery, token).ConfigureAwait(false);

            var viewBirdsList = new BirdsList
            {
                Birds = modelBirds.Select(BirdsConverter.Convert).ToList(),
            };

            return this.Ok(viewBirdsList);
        }
    }
}