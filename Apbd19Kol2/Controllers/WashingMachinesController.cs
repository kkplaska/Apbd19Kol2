using Apbd19Kol2.DTOs;
using Apbd19Kol2.Exceptions;
using Apbd19Kol2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Apbd19Kol2.Controllers;

[ApiController]
[Route("washing-machines")]
public class WashingMachinesController : ControllerBase
{
    private readonly IDbService _dbService;
    public WashingMachinesController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpPut("{orderId}/fulfill")]
    public async Task<IActionResult> FulfillOrder(int orderId, FulfillOrderDto dto)
    {
        try
        {
            await _dbService.FulfillOrder(orderId, dto);
            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ConflictException e)
        {
            return Conflict(e.Message);
        }
    }
}