using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Domain.Exceptions.Rental;

public class RentalNotFoundException : NotFoundExceptions
{
    public RentalNotFoundException()
    {
        this.TitleMessage = "Rental not found";
    }
}
