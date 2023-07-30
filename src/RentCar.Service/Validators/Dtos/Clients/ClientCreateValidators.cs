using FluentValidation;
using RentCar.Service.Common.Helpers;
using RentCar.Service.Dtos.Clients;

namespace RentCar.Service.Validators.Dtos.Clients;

public class ClientCreateValidators : AbstractValidator<ClientCreateDto>
{
    public ClientCreateValidators()
    {
        RuleFor(dto => dto.FirstName).NotNull().NotEmpty().WithMessage("Firstname filed is required!")
            .MinimumLength(3).WithMessage("Firstname must be more than 3 characters")
            .MaximumLength(50).WithMessage("Firstname must be less than 50 characters");

        RuleFor(dto => dto.LastName).NotNull().NotEmpty().WithMessage("Lastname filed is required!")
            .MinimumLength(3).WithMessage("Lastname must be more than 3 characters")
            .MaximumLength(50).WithMessage("Lastname must be less than 50 characters");

        RuleFor(dto => dto.PhoneNumber).Must(phone => PhoneNumberValidators.IsValid(phone))
            .WithMessage("Phone number is invalid! ex: +998xxYYYAABB");

        RuleFor(dto => dto.DriverLicense).Must(driverlicense => DriverLicenseValidators.IsValid(driverlicense))
            .WithMessage("Driver Lincense is invalid ex: AA123456");

        RuleFor(dto => dto.IsMale).NotNull().NotEmpty().WithMessage("Gender filed is required!");

        int maxImageSizeMB = 3;
        RuleFor(dto => dto.ImagePath).NotEmpty().NotNull().WithMessage("Image field is required");
        RuleFor(dto => dto.ImagePath.Length).LessThan(maxImageSizeMB * 1024 * 1024+1).WithMessage($"Image size must be less than {maxImageSizeMB} MB");
        RuleFor(dto => dto.ImagePath.FileName).Must(predicate =>
        {
            FileInfo fileInfo = new FileInfo(predicate);
            return MediaHelpers.GetImageExtension().Contains(fileInfo.Extension);
        }).WithMessage("This file type is not image file");

        RuleFor(dto => dto.Password).Must(password => PasswordValidators.IsStrongPassword(password).IsValid)
            .WithMessage("Password is not strong password!");

        RuleFor(dto => dto.Description).NotNull().NotEmpty().WithMessage("Description filed is required!")
            .MinimumLength(20).WithMessage("Description must be more than 20 characters");
    }
}
