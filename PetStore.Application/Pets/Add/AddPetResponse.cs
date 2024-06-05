namespace PetStore.Application.Pets.Add
{
    public class AddPetResponse : ResponseBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Color { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Description { get; set; }
    }
}
