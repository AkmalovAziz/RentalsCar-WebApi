using Microsoft.AspNetCore.Mvc;
using RentCar.DataAccess.Utils;
using RentCar.Service.Dtos.Clients;
using RentCar.Service.Interfaces.Clients;

namespace RentCar.WebApi.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IClientService _service;
        private readonly int maxPageSize = 30;

        public ClientController(IClientService service)
        {
            this._service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] ClientCreateDto dto)
            => Ok(await _service.CreateAsync(dto));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
            => Ok(await _service.GetAllAsync(new Paginationparams(page, maxPageSize)));

        [HttpGet("{clientId}")]
        public async Task<IActionResult> GetByIdAsync(long clientId)
            => Ok(await _service.GetByIdAsync(clientId));

        [HttpDelete("{clientId}")]
        public async Task<IActionResult> DeleteAsync(long clientId)
            => Ok(await _service.DeleteAsync(clientId));

        [HttpPut("{clientId}")]
        public async Task<IActionResult> UpdateAsync(long clientId, [FromForm] ClientUpdateDto dto)
            => Ok(await _service.UpdateAsync(clientId, dto));

        [HttpGet("count")]
        public async Task<IActionResult> CountAsync()
            => Ok(await _service.CountAsync());
    }
}
