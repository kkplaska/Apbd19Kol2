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
    
    [HttpPost]
    public async Task<IActionResult> AddWashingMachine(AddWashingMachineDto dto)
    {
        try
        {
            await _dbService.AddWashingMachine(dto);
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