using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Service.Validators.Dtos.Cars;

public class PriceValidator
{
    public static bool IsValid(float price)
    {
        if (price < 0) return false;
        if (price == 0) return false;
        else return true;
    }
}
