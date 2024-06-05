using MediatR;

namespace PetStore.Application.Pets.Add
{
    public class AddPetRequest : IRequest<ResponseBase>
    {
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Color { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Description { get; set; }
    }
}
