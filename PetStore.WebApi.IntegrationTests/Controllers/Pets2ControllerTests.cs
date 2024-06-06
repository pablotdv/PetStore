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

        public Pets2ControllerTests(BaseControllerFixture controllerFixture, ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("BaseControllerTests");
            ControllerFixture = controllerFixture;
            _output.WriteLine($"Fixture Instance ID: {ControllerFixture.InstanceId}");
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

        [Fact]
        public async Task AddPet_Should_Return_CreatedResponse_When_ValidRequest()
        {
            // Arrange
            var petRequest = new AddPetRequest
            {
                Name = "Fluffy",
                Breed = "Poodle",
                Color = "White",
                DateOfBirth = new DateTime(2019, 1, 1),
                Description = "A fluffy white poodle"
            };

            // Act
            var result = await ControllerFixture.HttpClient.PostAsJsonAsync("/api/pets", petRequest);

            // Arrange
            Assert.Equal(HttpStatusCode.Created, result.StatusCode);
        }

        [Fact]
        public async Task AddPet_Should_Return_CreatedResponse_With_Pet_When_ValidRequest()
        {
            // Arrange
            var petRequest = new AddPetRequest
            {
                Name = "Fluffy",
                Breed = "Poodle",
                Color = "White",
                DateOfBirth = new DateTime(2019, 1, 1),
                Description = "A fluffy white poodle"
            };

            // Act
            var result = await ControllerFixture.HttpClient.PostAsJsonAsync("/api/pets", petRequest);
            var petResponse = await result.Content.ReadFromJsonAsync<AddPetResponse>();

            // Arrange
            Assert.Equal(HttpStatusCode.Created, result.StatusCode);
            Assert.NotNull(petResponse);
            Assert.NotEqual(Guid.Empty, petResponse.Id);
            Assert.Equal(petRequest.Name, petResponse.Name);
            Assert.Equal(petRequest.Breed, petResponse.Breed);
            Assert.Equal(petRequest.Color, petResponse.Color);
            Assert.Equal(petRequest.DateOfBirth, petResponse.DateOfBirth);
            Assert.Equal(petRequest.Description, petResponse.Description);
        }
    }
}
