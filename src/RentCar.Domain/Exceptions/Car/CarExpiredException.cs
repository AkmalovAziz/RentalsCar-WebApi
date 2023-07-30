using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Domain.Exceptions.Car;

public class CarExpiredException : ExpiredExceptions
{
    public CarExpiredException()
    {
        TitleMessage = "Car data has expired!";
    }
}
