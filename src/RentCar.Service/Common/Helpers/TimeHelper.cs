using RentCar.Domain.Constans;

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
