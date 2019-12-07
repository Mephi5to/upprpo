using System;
using Model = Birds.Models.Birds;
using ClientModel = Birds.ClientModels.Birds;

namespace Birds.API.Converters
{      
    public static class BirdsConverter
    {
        public static Model.BirdBuildInfo Convert(ClientModel.BirdBuildInfo buildInfo)
        {
            if (buildInfo == null)
            {
                throw new ArgumentNullException(nameof(buildInfo));
            }

            var modelBuildInfo = new Model.BirdBuildInfo
            {
                Description = buildInfo.Description,
                Name = buildInfo.Name,
                AudioFileId = buildInfo.AudioFileId,
                ImageFileId = buildInfo.ImageFileId,
            };

            return modelBuildInfo;
        }

        public static ClientModel.Bird Convert(Model.Bird modelBird)
        {
            if (modelBird == null)
            {
                throw new ArgumentNullException(nameof(modelBird));
            }

            var clientBird = new ClientModel.Bird
            {
                Description = modelBird.Description,
                Id = modelBird.Id,
                Name = modelBird.Name,
                AudioFileId = modelBird.AudioFileId,
                ImageFileId = modelBird.ImageFileId,
            };

            return clientBird;
        }

        public static Model.BirdsSearchQuery Convert(ClientModel.BirdsSearchQuery clientSearchQuery)
        {
            var offset = clientSearchQuery?.Offset ?? 0;
            var limit = clientSearchQuery?.Limit ?? 100;
            
            var modelSearchQuery = new Model.BirdsSearchQuery(offset, limit)
            {
                Name = clientSearchQuery?.Name,
            };

            return modelSearchQuery;
        }
    }
}