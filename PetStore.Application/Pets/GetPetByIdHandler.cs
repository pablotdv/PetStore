using MediatR;
using PetoStore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Application.Pets
{

    public class GetPetByIdHandler : IRequestHandler<GetPetByIdRequest, ResponseBase>
    {
        private readonly IPetRepository _petRepository;
        public GetPetByIdHandler(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }
        public async Task<ResponseBase> Handle(GetPetByIdRequest request, CancellationToken cancellationToken)
        {
            var pet = await _petRepository.GetAsync(request.Id);
            if (pet is null)
                return new NotFoundResponse();

            return new GetPetByIdResponse
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
