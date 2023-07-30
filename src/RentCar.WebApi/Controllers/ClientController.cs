using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentCar.DataAccess.Utils;
using RentCar.Service.Dtos.Clients;
using RentCar.Service.Interfaces.Clients;
using RentCar.Service.Validators.Dtos.Clients;
using System.Data;

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

        [HttpGet]
        [AllowAnonymous]

        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
            => Ok(await _service.GetAllAsync(new Paginationparams(page, maxPageSize)));

        [HttpGet]
        [Route("{clientId}")]
        [AllowAnonymous]

        public async Task<IActionResult> GetByIdAsync(long clientId)
            => Ok(await _service.GetByIdAsync(clientId));

        [HttpDelete]
        [Route("{clientId}")]
        [Authorize(Roles ="Admin")]

        public async Task<IActionResult> DeleteAsync(long clientId)
            => Ok(await _service.DeleteAsync(clientId));

        [HttpPut]
        [Route("{clientId}")]

        public async Task<IActionResult> UpdateAsync(long clientId, [FromForm] ClientUpdateDto dto)
        {
            var updatevalidator = new ClientUpdateValidators();
            var updateResult = updatevalidator.Validate(dto);
            if (updateResult.IsValid) return Ok(await _service.UpdateAsync(clientId, dto));
            else return BadRequest(updateResult.Errors);
        }

        [HttpGet]
        [Route("count")]
        [AllowAnonymous]
        public async Task<IActionResult> CountAsync()
            => Ok(await _service.CountAsync());
    }
}
