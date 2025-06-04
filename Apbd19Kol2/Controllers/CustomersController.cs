using Apbd19Kol2.DTOs;
using Apbd19Kol2.Exceptions;
using Apbd19Kol2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Apbd19Kol2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly IDbService _dbService;
    public CustomersController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{id}/purchases")]
    public async Task<IActionResult> GetPurchasesByCustomerId(int customerId)
    {
        try
        {
            var order = await _dbService.GetPurchasesByCustomerId(customerId);
            return Ok(order);
        }
        catch (NotFoundException e)
        {
            return NotFound($"Customer with {customerId} purchases not found");
        }
    }
}