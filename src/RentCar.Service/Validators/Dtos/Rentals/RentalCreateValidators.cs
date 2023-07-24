using FluentValidation;
using RentCar.Service.Dtos.Rentals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Service.Validators.Dtos.Rentals;

public class RentalCreateValidators : AbstractValidator<RentalsCreateDto>
{
    public RentalCreateValidators()
    {
        RuleFor(dto => dto.StartDate).Must(startdate => StartEndDateValidators.IsValid(startdate))
            .WithMessage("Start Date is invalid ex: 01.01.2001");

        RuleFor(dto => dto.EndDate).Must(startdate => StartEndDateValidators.IsValid(startdate))
            .WithMessage("End Date is invalid ex: 01.01.2001");

        RuleFor(dto => dto.Destination).NotNull().NotEmpty().WithMessage("Destination is required!")
            .MinimumLength(10).WithMessage("Destination must be more than 10 characters");

        RuleFor(dto => dto.Payment).NotEmpty().WithMessage("Payment type is required!");

        RuleFor(dto => dto.IsPayment).NotEmpty().WithMessage("Payment is required!");

        RuleFor(dto => dto.Description).NotNull().NotEmpty().WithMessage("Description is required!")
            .MinimumLength(20).WithMessage("Description must be more than 20 characters");
    }
}
