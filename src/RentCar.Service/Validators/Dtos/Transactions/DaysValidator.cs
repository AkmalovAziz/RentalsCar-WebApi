using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Service.Validators.Dtos.Transactions;

public class DaysValidator
{
    public static bool IsValid(int day)
    {
        if (day < 0) return false;
        if (day == 0) return false;

        return true;
    }
}
