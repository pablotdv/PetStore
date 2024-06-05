using FluentValidation;

namespace PetStore.Application.Pets.Add
{
    public class AddPetValidator : AbstractValidator<AddPetRequest>
    {
        public AddPetValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Breed).NotEmpty();
            RuleFor(x => x.Color).NotEmpty();
            RuleFor(x => x.DateOfBirth).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
