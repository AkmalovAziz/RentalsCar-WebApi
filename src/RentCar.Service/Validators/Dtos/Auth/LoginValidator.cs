using FluentValidation;
using RentCar.Service.Dtos.Auth;

namespace RentCar.Service.Validators.Dtos.Auth;

public class LoginValidator : AbstractValidator<LoginDto>
{
    public LoginValidator()
    {
        RuleFor(dto => dto.PhoneNumber).Must(phone => PhoneNumberValidators.IsValid(phone))
            .WithMessage("Phone number is invalid! ex: +998xxYYYAABB");

        RuleFor(dto => dto.Password).Must(password => PasswordValidators.IsStrongPassword(password).IsValid)
            .WithMessage("Password is not strong password!");
    }
}
