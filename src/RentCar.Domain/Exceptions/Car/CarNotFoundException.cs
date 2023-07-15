using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Domain.Exceptions.Car;

public class CarNotFoundException : NotFoundExceptions
{
    public CarNotFoundException()
    {
        this.TitleMessage = "Car not found";
    }
}
