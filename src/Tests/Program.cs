using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Birds.Models;
using Birds.Models.Birds;
using Birds.Models.Birds.Repository;

namespace Tests
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var temp = new List<Bird>
            {
                new Bird { Name = "Зяблик", Description = "описание зяблика" },
                new Bird { Name = "Ворон", Description = "описание ворона" },
                new Bird { Name = "Воробей", Description = "описание воробья" },
                new Bird { Name = "Рябчик", Description = "описание рябчика" },
            };

            var config = new Configuration();
            var birdsRepository = new BirdsRepository(config);
            
            var searchQuery = new BirdsSearchQuery();
            var searchResult = await birdsRepository.SearchAsync(searchQuery, CancellationToken.None)
                .ConfigureAwait(false);

            foreach (var bird in searchResult)
            {
                Console.WriteLine(bird.Name);
            }
        }
    }
}