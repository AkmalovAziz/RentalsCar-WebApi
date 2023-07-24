using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentCar.DataAccess.Utils;
using RentCar.Service.Dtos.Transactions;
using RentCar.Service.Interfaces.Transactions;

namespace RentCar.WebApi.Controllers;

[Route("api/transaction")]
[ApiController]
public class TransactionController : ControllerBase
{
    private ITransactionService _service;
    private readonly int maxPageSize = 10;

    public TransactionController(ITransactionService transactionservice)
    {
        this._service = transactionservice;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateAsync([FromForm] TransactionCreateDto dto)
        => Ok(await _service.CreateAsync(dto));

    [HttpGet("{transactionId}")]
    [AllowAnonymous]

    public async Task<IActionResult> GetByIdAsync(long transactionId)
        => Ok(await _service.GetByIdAsync(transactionId));

    [HttpDelete("{transactionId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(long transactionId)
        => Ok(await _service.DeleteAsync(transactionId));

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllAsync([FromBody] int pagesize = 1)
        => Ok(await _service.GetAllAsync(new Paginationparams(maxPageSize, pagesize)));

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> CountAsync() => Ok(await _service.CountAsync());
}
