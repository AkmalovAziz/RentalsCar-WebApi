using RentCar.Domain.Constans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Service.Common.Helpers;

public class TimeHelper
{
    public static DateTime GetDateTime()
    {
        var datetime = DateTime.UtcNow;
        datetime.AddHours(TimeConstans.UTC);
        return datetime;
    }
}
