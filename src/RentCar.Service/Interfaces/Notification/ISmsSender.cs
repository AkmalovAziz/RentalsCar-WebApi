using RentCar.Service.Dtos.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Service.Interfaces.Notification;

public interface ISmsSender
{
    public Task<bool> SendAsync(SmsMessage smsMessage);
}
