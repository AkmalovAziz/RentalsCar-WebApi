using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentCar.Service.Dtos.Notification;
using RentCar.Service.Interfaces.Notification;
using System.Data;

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
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> SendAsync([FromBody] SmsMessage smsMessage)
        {
            return Ok(await _smsSender.SendAsync(smsMessage));
        }
    }
}
