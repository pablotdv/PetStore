using MediatR;

namespace PetStore.Application.Pets.GetById
{
    public class GetPetByIdRequest : IRequest<ResponseBase>
    {
        public Guid Id { get; set; }
    }
}
