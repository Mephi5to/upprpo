using System;
using System.Threading;
using System.Threading.Tasks;
using Birds.ClientModels.Files;
using Birds.Models.Files.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Birds.API.Controllers
{
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
                throw new ArgumentNullException(nameof(creationInfo));
            }

            var fileId = await filesRepository.CreateAsync(creationInfo.Data, creationInfo.Name, token).ConfigureAwait(false);

            return Ok(new { id = fileId });
        }

        [HttpPost]
        public async Task<IActionResult> GetAsync(string id, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            var bytes = await filesRepository.GetAsync(id, token).ConfigureAwait(false);

            var file = new File
            {
                Bytes = bytes,
            };
            
            return Ok(file);
        }
    }
}