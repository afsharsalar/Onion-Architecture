using FluentValidation;

namespace ApplicationService.Models.User
{
    public class AddUserDtoValidation : AbstractValidator<AddUserDto>
    {
        public AddUserDtoValidation()
        {
            RuleFor(m => m.Mobile)
                .NotEmpty().WithMessage("Mobile is required")
                .Length(11).WithMessage("Mobile mus be 11 digits");
        }
    }
}
