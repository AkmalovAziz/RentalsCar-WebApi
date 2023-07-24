using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentCar.DataAccess.Utils;
using RentCar.Service.Dtos.Rentals;
using RentCar.Service.Interfaces.Rentals;
using RentCar.Service.Validators.Dtos.Rentals;

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
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> CreatAsync([FromForm] RentalsCreateDto dto)
        {
            var createvalidator = new RentalCreateValidators();
            var resultValidator = createvalidator.Validate(dto);
            if (resultValidator.IsValid) return Ok(await _service.CreateAsync(dto));
            else return BadRequest(resultValidator.Errors);
        }

        [HttpGet("{rentalId}")]
        [AllowAnonymous]

        public async Task<IActionResult> GetByIdAsync(long rentalId)
            => Ok(await _service.GetByIdAsync(rentalId));

        [HttpDelete("{rentalId}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeleteAsync(long rentalId)
            => Ok(await _service.DeleteAsync(rentalId));

        [HttpGet("count")]
        [AllowAnonymous]

        public async Task<IActionResult> CountAsync()
            => Ok(await _service.CountAsync());

        [HttpPut("{rentalId}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> UpdateAsync(long rentalId, [FromForm] RentalsUpdateDto dto)
        {
            var updatevalidator = new RentalUpdateValidators();
            var resultValdator = updatevalidator.Validate(dto);
            if (resultValdator.IsValid) return Ok(await _service.UpdateAsync(rentalId, dto));
            else return BadRequest(resultValdator.Errors);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
            => Ok(await _service.GetAllAsync(new Paginationparams(page, maxPageSize)));
    }
}
