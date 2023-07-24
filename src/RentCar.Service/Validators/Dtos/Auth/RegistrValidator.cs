using FluentValidation;
using Microsoft.AspNetCore.Identity;
using RentCar.Service.Dtos.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Service.Validators.Dtos.Auth;

public class RegistrValidator : AbstractValidator<RegistrDto>
{
    public RegistrValidator()
    {
        RuleFor(dto => dto.FirstName).NotNull().NotEmpty().WithMessage("Firstname is required!")
            .MaximumLength(30).WithMessage("Firstname must be less than 30 characters");

        RuleFor(dto => dto.LastName).NotNull().NotEmpty().WithMessage("Lastname is required!")
            .MaximumLength(30).WithMessage("Lastname must be less than 30 characters");

        RuleFor(dto => dto.PhoneNumber).Must(phone => PhoneNumberValidators.IsValid(phone))
            .WithMessage("Phone number is invalid! ex: +998xxYYYAABB");

        RuleFor(dto => dto.Password).Must(password => PasswordValidators.IsStrongPassword(password).IsValid)
            .WithMessage("Password is not strong password!");
    }
}
