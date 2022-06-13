using FluentValidation;

namespace ApplicationService.Models.User
{
    public class LoginUserDtoValidation : AbstractValidator<LoginUserDto>
    {
        public LoginUserDtoValidation()
        {
            RuleFor(c => c.Mobile).NotEmpty().WithMessage("برای موبایل مقدار لازم است")
                .Length(11).WithMessage("موبایل 11 رقم می‌باشد");

            RuleFor(c => c.Password).NotEmpty().WithMessage("برای پسورد مقدار لازم است");
        }
    }
}
