using FluentValidation;
using RentCar.Service.Dtos.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Service.Validators.Dtos.Transactions;

public class TransactionUpdateValidator : AbstractValidator<TransactionUpdateDto>
{
    public TransactionUpdateValidator()
    {
        RuleFor(dto => dto.Description).NotEmpty().NotNull().WithMessage("Description is required!")
            .MinimumLength(20).WithMessage("Description must be more than 10 characters");
    }
}
