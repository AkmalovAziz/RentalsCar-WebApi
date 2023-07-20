using Microsoft.AspNetCore.Mvc;
using RentCar.DataAccess.Utils;
using RentCar.Service.Dtos.Rentals;
using RentCar.Service.Interfaces.Rentals;

namespace RentCar.WebApi.Controllers
{
    [Route("api/rental")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private IRentalService _service;
        private readonly int maxPageSize = 30;

        public RentalController(IRentalService service)
        {
            this._service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreatAsync([FromForm] RentalsCreateDto dto)
            => Ok(await _service.CreateAsync(dto));

        [HttpGet("{rentalId}")]
        public async Task<IActionResult> GetByIdAsync(long rentalId)
            => Ok(await _service.GetByIdAsync(rentalId));

        [HttpDelete("{rentalId}")]
        public async Task<IActionResult> DeleteAsync(long rentalId)
            => Ok(await _service.DeleteAsync(rentalId));

        [HttpGet("count")]
        public async Task<IActionResult> CountAsync()
            => Ok(await _service.CountAsync());

        [HttpPut("{rentalId}")]
        public async Task<IActionResult> UpdateAsync(long rentalId, [FromForm] RentalsUpdateDto dto)
            => Ok(await _service.UpdateAsync(rentalId, dto));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
            => Ok(await _service.GetAllAsync(new Paginationparams(page, maxPageSize)));
    }
}
