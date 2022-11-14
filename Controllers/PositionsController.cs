using Microsoft.AspNetCore.Mvc;
using TechnicalTask.DataAccess;

namespace TechnicalTask.Controllers;

[ApiController]
[Route("api/positions")]
public class PositionsController : ControllerBase
{

    private readonly IPositionsDataAccess _positionsDataAccess;

    public PositionsController(ILogger<AddressesController> logger, IPositionsDataAccess positionsDataAccess)
    {
        _positionsDataAccess = positionsDataAccess;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var positions = await _positionsDataAccess.GetPositions();
            return Ok(positions);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
}