using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonTracker.Domain.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;

namespace AmazonTracker.Domain.Repository
{
    public class ReviewResultRepository : IReviewResultRepository
    {
        private readonly Container _container;
        private readonly IConfiguration _configuration;

        public ReviewResultRepository(IConfiguration configuration)
        {
            _configuration = configuration;

            string databaseName = _configuration.GetSection("CosmosDb").GetSection("DatabaseName").Value;
            string containerName = _configuration.GetSection("CosmosDb").GetSection("ContainerName").Value;
            string account = _configuration.GetSection("CosmosDb").GetSection("Account").Value;
            string key = _configuration.GetSection("CosmosDb").GetSection("Key").Value;

            CosmosClient client = new CosmosClient(account, key);
            _container = client.GetContainer(databaseName, containerName);
        }


        public async Task AddItemAsync(ReviewResult item)
        {
            await _container.CreateItemAsync<ReviewResult>(item, new PartitionKey(item.Id));
        }

        public async Task<ReviewResult> GetItemAsync(string id)
        {
            try
            {
                var response = await _container.ReadItemAsync<ReviewResult>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<IEnumerable<ReviewResult>> GetItemsAsync(string queryString)
        {
            var query = _container.GetItemQueryIterator<ReviewResult>(new QueryDefinition(queryString));
            var results = new List<ReviewResult>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task UpdateItemAsync(string id, ReviewResult item)
        {
            await _container.UpsertItemAsync<ReviewResult>(item, new PartitionKey(id));
        }

        public async Task DeleteItemAsync(string id)
        {
            await _container.DeleteItemAsync<ReviewResult>(id, new PartitionKey(id));
        }
    }
}
