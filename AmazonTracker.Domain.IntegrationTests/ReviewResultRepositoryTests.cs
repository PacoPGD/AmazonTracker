using AmazonTracker.Domain.Models;
using AmazonTracker.Domain.Repository;
using Microsoft.Extensions.Configuration;
using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace AmazonTracker.Domain.IntegrationTests
{
    public class ReviewResultRepositoryTests
    {
        [Fact(Skip = "This test aren't finish")]
        public async void AddItemAsyncPassed()
        {
            // Arrange
            TrackReviewsEntity pr = JsonConvert.DeserializeObject<TrackReviewsEntity>(File.ReadAllText(Directory.GetCurrentDirectory() + "..\\..\\..\\..\\test.json"));
            ReviewResult result = pr.ResultList[0];

            var UnitOfWork = new Mock<UnitOfWork>();

            IConfiguration mockConfiguration = GetMockConfiguration();

            var repository = new ReviewResultRepository(mockConfiguration);

            //Clean
            if (await repository.GetItemAsync(result.Id)!=null)
                await repository.DeleteItemAsync(result.Id);

            //Act
            await repository.AddItemAsync(result);

            //Assert
            ReviewResult dbResult = await repository.GetItemAsync(result.Id);

            var dbResultJson = JsonConvert.SerializeObject(dbResult);
            var resultJson = JsonConvert.SerializeObject(result);

            Assert.Equal(dbResultJson, resultJson);

            //Clean
            await repository.DeleteItemAsync(result.Id);
        }

        private IConfiguration GetMockConfiguration()
        {
            var inMemorySettings = new Dictionary<string, string> {
                {"CosmosDb:DatabaseName", "TestDatabaseHomeProject"},
                {"CosmosDb:ContainerName", "ContainerHomeProject"},
                {"CosmosDb:Account", "https://homeprojectaccount.documents.azure.com:443/"},
                {"CosmosDb:Key", "F4jBzlixhFxptQzxs2Cku4JtPs2keOvhDjsS65ouOzuTHwrGlGKcWyoY5QuWQ96Jy8I3w1gRwDef2fC25axigQ=="},
            };

            return new ConfigurationBuilder().AddInMemoryCollection(inMemorySettings).Build();
        }

    }
}
