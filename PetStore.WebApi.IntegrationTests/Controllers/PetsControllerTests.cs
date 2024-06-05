using PetStore.Application.Pets.Add;
using PetStore.Infrastructure.UnitTests.SharedContexts;
using System.Net;
using System.Net.Http.Json;
using Xunit.Abstractions;

namespace PetStore.WebApi.IntegrationTests.Controllers
{
    [Collection(nameof(ApiSharedContextCollection))]
    public class PetsControllerTests
    {
        private readonly ITestOutputHelper _output;
        public BaseControllerFixture ControllerFixture { get; }

        public PetsControllerTests(BaseControllerFixture controllerFixture, ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("BaseControllerTests");
            ControllerFixture = controllerFixture;
            _output.WriteLine($"Fixture Instance ID: {ControllerFixture.InstanceId}");
        }

        [Fact]
        public async Task AddPet_Should_Return_Name_IsEmpety()
        {
            // Arrange
            var petRequest = new AddPetRequest
            {
                Name = "",
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


    }
}
