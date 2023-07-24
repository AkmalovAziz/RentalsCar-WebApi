using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Service.Validators.Dtos;

public class StartEndDateValidators
{
    public static bool IsValid(string date)
    {
        if (date.Length != 9) return false;

        if (date[2] != '.' && date[5] != '.') return false;

        for(int i = 0; i < date.Length; i++)
        {
            if (i == 2 || i == 5) continue;
            else if (char.IsDigit(date[i])) continue;
            else return false;
        }

        return true;
    }
}
