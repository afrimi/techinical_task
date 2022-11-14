using Microsoft.AspNetCore.Mvc;
using TechnicalTask.DataAccess;

namespace TechnicalTask.Controllers;

[ApiController]
[Route("api/addresses")]
public class AddressesController : ControllerBase
{

    private readonly IAddressesDataAccess _addressesDataAccess;

    public AddressesController(IAddressesDataAccess addressesDataAccess)
    {
        _addressesDataAccess = addressesDataAccess;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var addresses = await _addressesDataAccess.GetAddresses();
            return Ok(addresses);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
}