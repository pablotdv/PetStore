using DotNet.Testcontainers.Builders;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PetStore.Infrastructure.Database;
using Testcontainers.MsSql;

namespace PetStore.WebApi.IntegrationTests.Controllers
{
    public class PetsControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;
        private readonly MsSqlContainer _sqlServerContainer;
        public PetsControllerTests(WebApplicationFactory<Program> webApplicationFactory)
        {
            _sqlServerContainer = new MsSqlBuilder()
                .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
                .WithPassword("Password1234@")
                .WithPortBinding(1434, 1433)
                .WithCleanUp(true)
                .WithAutoRemove(true)
                .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(1434))
                .Build();
            _sqlServerContainer.StartAsync().Wait();


            var host = webApplicationFactory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddDbContext<PetStoreContext>(options =>
                    {
                        options.UseSqlServer(_sqlServerContainer.GetConnectionString());
                    });
                });
            });
            _httpClient = webApplicationFactory.CreateClient(
                new WebApplicationFactoryClientOptions
                {
                    BaseAddress = new Uri("http://localhost:5000")
                });

            var a = _sqlServerContainer.ExecScriptAsync("CREATE TABLE Pets (\r\n    Id UNIQUEIDENTIFIER PRIMARY KEY,\r\n    Name NVARCHAR(255) NOT NULL,\r\n    Breed NVARCHAR(255) NOT NULL,\r\n    Color NVARCHAR(255) NOT NULL,\r\n    DateOfBirth DATETIME2 NOT NULL,\r\n    Description NVARCHAR(MAX) NOT NULL\r\n);\r\n\r\n\r\nINSERT INTO Pets (Id, Name, Breed, Color, DateOfBirth, Description)\r\nVALUES \r\n(NEWID(), 'Buddy', 'Golden Retriever', 'Golden', '2017-03-15', 'Friendly and playful. Loves to fetch.'),\r\n(NEWID(), 'Mittens', 'Siamese', 'Cream', '2019-07-23', 'Curious and vocal. Enjoys climbing.'),\r\n(NEWID(), 'Max', 'German Shepherd', 'Black and Tan', '2018-11-02', 'Loyal and protective. Great guard dog.'),\r\n(NEWID(), 'Whiskers', 'Tabby', 'Gray', '2020-05-18', 'Calm and affectionate. Loves to nap.'),\r\n(NEWID(), 'Charlie', 'Beagle', 'Tricolor', '2016-01-10', 'Energetic and friendly. Excellent scent tracker.');\r\n;").ConfigureAwait(false).GetAwaiter().GetResult();
        }

        [Fact]
        public async Task Should_Return_OkResponse()
        {
            // Arrange

            // Act 
            var response = await _httpClient.GetAsync("/pets");

            // Assert
        }

        public void Dispose()
        {
            _sqlServerContainer.StopAsync().Wait();
        }
    }
}
