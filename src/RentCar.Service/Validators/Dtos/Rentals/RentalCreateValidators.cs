using FluentValidation;
using RentCar.Service.Dtos.Rentals;
using RentCar.Service.Validators.Dtos.Cars;
using RentCar.Service.Validators.Dtos.Transactions;

namespace RentCar.Service.Validators.Dtos.Rentals;

public class RentalCreateValidators : AbstractValidator<RentalsCreateDto>
{
    public RentalCreateValidators()
    {
        RuleFor(dto => dto.Days).NotNull().Must(days => DaysValidator.IsValid(days))
            .WithMessage("Days field is required!");

        RuleFor(dto => dto.Destination).NotNull().NotEmpty().WithMessage("Destination is required!")
            .MinimumLength(10).WithMessage("Destination must be more than 10 characters");

        RuleFor(dto => dto.Description).NotNull().NotEmpty().WithMessage("Description is required!")
            .MinimumLength(20).WithMessage("Description must be more than 20 characters");
    }
}
