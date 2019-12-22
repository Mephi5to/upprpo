using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Birds.Models.Birds.Repository
{
    public sealed class BirdsRepository : IBirdsRepository
    {
        public readonly IMongoCollection<Bird> birds;

        public BirdsRepository(Configuration config)
        {
            var client = new MongoClient(config.GetConnectionString("BirdsDb"));
            var database = client.GetDatabase("BirdsDb");
            this.birds = database.GetCollection<Bird>("Birds");
        }
        
        public async Task<IReadOnlyList<Bird>> SearchAsync(BirdsSearchQuery query, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            var nameFilter = Builders<Bird>.Filter.Empty;

            if (query.Name != null)
            {
                nameFilter = Builders<Bird>.Filter.Regex("Name", new BsonRegularExpression(query.Name));
            }
            
            var result = await birds.Find(nameFilter).Skip(query.Offset).Limit(query.Limit).ToListAsync(token);
            return result;
        }

        public async Task<IReadOnlyList<Bird>> CreateBatchAsync(IReadOnlyList<BirdBuildInfo> batchBuildInfo, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            
            if (batchBuildInfo == null)
            {
                throw new ArgumentNullException(nameof(batchBuildInfo));
            }

            if (batchBuildInfo.Count == 0)
            {
                return new List<Bird>(0);
            }
            
            var newBirds = batchBuildInfo.Select(creationInfo => new Bird
                {
                    Name = creationInfo.Name,
                    Description = creationInfo.Description,
                    AudioFileId = creationInfo.AudioFileId,
                    ImageFileId = creationInfo.ImageFileId,
                }).ToList();
            
            await birds.InsertManyAsync(newBirds, cancellationToken: token).ConfigureAwait(false);

            return newBirds;
        }

        public async Task<Bird> GetAsync(string id, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            
            var search = await this.birds
                .FindAsync(it => it.Id == id, cancellationToken:token)
                .ConfigureAwait(false);

            var bird = search.FirstOrDefault();

            if (bird == null)
            {
                throw new ItemNotFoundException("bird", id);
            }
            
            return bird;
        }
    }
}