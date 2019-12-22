using System;
using System.Threading;
using System.Threading.Tasks;
using Birds.ClientModels.Files;
using Birds.Models.Files.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Birds.API.Controllers
{
    [Route("api/v1/files")]
    public sealed class FilesController : ControllerBase
    {
        private readonly IFilesRepository filesRepository;

        public FilesController(IFilesRepository filesRepository)
        {
            this.filesRepository = filesRepository ?? throw new ArgumentNullException(nameof(filesRepository));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(
            [FromBody] FileCreationInfo creationInfo,
            CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            
            if (creationInfo == null)
            {
                return BadRequest($"creationInfo cannot be null");
            }

            var fileId = await filesRepository.CreateAsync(creationInfo.Data, creationInfo.Name, token).ConfigureAwait(false);
            var creationResult = new FileCreationResultInfo
            {
                Id = fileId,
            };
            
            return Ok(creationResult);
        }

        [HttpGet("{id}", Name = "GetFile")]
        public async Task<IActionResult> GetAsync(string id, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            var data = await filesRepository.GetAsync(id, token).ConfigureAwait(false);

            var file = new File
            {
                Data = data,
            };
            
            return Ok(file);
        }
    }
}