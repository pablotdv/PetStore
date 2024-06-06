using PetStore.Application.Pets.Add;
using PetStore.Infrastructure.UnitTests.SharedContexts;
using System.Net;
using System.Net.Http.Json;
using Xunit.Abstractions;

namespace PetStore.WebApi.IntegrationTests.Controllers
{
    [Collection(nameof(ApiSharedContextCollection))]
    public class Pets2ControllerTests
    {
        private readonly ITestOutputHelper _output;
        public BaseControllerFixture ControllerFixture { get; }
        private readonly TestSharedContext _testSharedContext;

        public Pets2ControllerTests(BaseControllerFixture controllerFixture, TestSharedContext testSharedContext, ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("BaseControllerTests");
            ControllerFixture = controllerFixture;
            _output.WriteLine($"Fixture Instance ID: {ControllerFixture.InstanceId}");
            _testSharedContext = testSharedContext;
            _output.WriteLine($"testSharedContext Instance ID: {testSharedContext.InstanceId}");
        }

        [Fact]
        public async Task AddPet_Should_Return_BadRequest_When_Name_IsNull()
        {
            // Arrange
            var petRequest = new AddPetRequest
            {
                Name = null,
                Breed = "Poodle",
                Color = "White",
                DateOfBirth = new DateTime(2019, 1, 1),
                Description = "A fluffy white poodle"
            };

            // Act
            var result = await ControllerFixture.HttpClient.PostAsJsonAsync("/api/pets", petRequest);

            // Arrange
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public async Task AddPet_Should_Return_BadRequest_When_Breed_IsNull()
        {
            // Arrange
            var petRequest = new AddPetRequest
            {
                Name = "Fluffy",
                Breed = null,
                Color = "White",
                DateOfBirth = new DateTime(2019, 1, 1),
                Description = "A fluffy white poodle"
            };

            // Act
            var result = await ControllerFixture.HttpClient.PostAsJsonAsync("/api/pets", petRequest);

            // Arrange
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }      
    }
}
