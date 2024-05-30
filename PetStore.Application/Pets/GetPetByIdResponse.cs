namespace PetStore.Application.Pets
{
    public class GetPetByIdResponse : ResponseBase
{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Color { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Description { get; set; }
    }
}
