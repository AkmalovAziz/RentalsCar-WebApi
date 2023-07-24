using RentCar.Service.Dtos.Notification;

namespace RentCar.Service.Interfaces.Notification;

public interface ISmsSender
{
    public Task<bool> SendAsync(SmsMessage smsMessage);
}
