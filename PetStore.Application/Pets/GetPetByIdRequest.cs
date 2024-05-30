using MediatR;

namespace PetStore.Application.Pets
{
    public class GetPetByIdRequest : IRequest<ResponseBase>
    {
        public Guid Id { get; set; }
    }
}
