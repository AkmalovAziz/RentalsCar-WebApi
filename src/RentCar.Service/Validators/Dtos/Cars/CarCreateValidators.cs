using FluentValidation;
using RentCar.Service.Dtos.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Service.Validators.Dtos.Cars;

public class CarCreateValidators : AbstractValidator<CarsCreateDto>
{
    public CarCreateValidators()
    {
        RuleFor(dto => dto.Name).NotNull().NotEmpty().WithMessage("Name filed is required!")
            .MinimumLength(3).WithMessage("Name must be more than 3 characters")
            .MaximumLength(50).WithMessage("Name must be less than 50 characters");
    }
}
