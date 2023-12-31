﻿using FluentValidation;
using RentCar.Service.Common.Helpers;
using RentCar.Service.Dtos.Cars;

namespace RentCar.Service.Validators.Dtos.Cars;

public class CarCreateValidators : AbstractValidator<CarsCreateDto>
{
    public CarCreateValidators()
    {
        RuleFor(dto => dto.Name).NotNull().NotEmpty().WithMessage("Name filed is required!")
            .MinimumLength(3).WithMessage("Name must be more than 3 characters")
            .MaximumLength(50).WithMessage("Name must be less than 50 characters");

        RuleFor(dto => dto.Model).NotNull().NotEmpty().WithMessage("Model filed is required!")
            .MinimumLength(3).WithMessage("Model must be more than 3 characters")
            .MaximumLength(50).WithMessage("Model must be less than 50 characters");

        int maxImageSizeMB = 3;
        RuleFor(dto => dto.ImagePath).NotEmpty().NotNull().WithMessage("Image field is required");
        RuleFor(dto => dto.ImagePath.Length).LessThan(maxImageSizeMB * 1024 * 1024).WithMessage($"Image size must be less than {maxImageSizeMB} MB");
        RuleFor(dto => dto.ImagePath.FileName).Must(predicate =>
        {
            FileInfo fileInfo = new FileInfo(predicate);
            return MediaHelpers.GetImageExtension().Contains(fileInfo.Extension);
        }).WithMessage("This file type is not image file");

        RuleFor(dto => dto.PriceOfDate).Must(price => PriceValidator.IsValid(price))
            .WithMessage("Price is required!");

        RuleFor(dto => dto.Description).NotNull().NotEmpty().WithMessage("Description filed is required!")
            .MinimumLength(20).WithMessage("Description filed is required!");

    }
}
