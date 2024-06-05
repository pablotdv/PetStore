using MediatR;
using PetoStore.Domain.Pets;
using PetoStore.Domain.Repositories;

namespace PetStore.Application.Pets.Add
{
    public class AddPetHandler : IRequestHandler<AddPetRequest, ResponseBase>
    {
        private readonly IPetRepository _petRepository;

        public AddPetHandler(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public async Task<ResponseBase> Handle(AddPetRequest request, CancellationToken cancellationToken)
        {
            var pet = new Pet
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Breed = request.Breed,
                Color = request.Color,
                DateOfBirth = request.DateOfBirth,
                Description = request.Description
            };

            await _petRepository.AddAsync(pet, cancellationToken);

            return new AddPetResponse
            {
                Id = pet.Id,
                Name = pet.Name,
                Breed = pet.Breed,
                Color = pet.Color,
                DateOfBirth = pet.DateOfBirth,
                Description = pet.Description
            };
        }
    }
}
