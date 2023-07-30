using FluentValidation;
using RentCar.Service.Dtos.Rentals;

namespace RentCar.Service.Validators.Dtos.Rentals;

public class RentalUpdateValidators : AbstractValidator<RentalsUpdateDto>
{
    public RentalUpdateValidators()
    {
        RuleFor(dto => dto.Destination).NotNull().NotEmpty().WithMessage("Destination is required!")
            .MinimumLength(10).WithMessage("Destination must be more than 10 characters");

        RuleFor(dto => dto.Description).NotNull().NotEmpty().WithMessage("Description is required!")
            .MinimumLength(20).WithMessage("Description must be more than 20 characters");
    }
}
