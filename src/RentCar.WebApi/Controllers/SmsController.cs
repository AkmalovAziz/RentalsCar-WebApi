using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentCar.Service.Dtos.Notification;
using RentCar.Service.Interfaces.Notification;

namespace RentCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        private readonly ISmsSender _smsSender;
        public SmsController(ISmsSender smsSender)
        {
            this._smsSender = smsSender;
        }

        [HttpPost]
        public async Task<IActionResult> SendAsync([FromBody] SmsMessage smsMessage)
        {
            return Ok(await _smsSender.SendAsync(smsMessage));
        }
    }
}
