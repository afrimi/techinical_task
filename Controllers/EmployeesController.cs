using Microsoft.AspNetCore.Mvc;
using TechnicalTask.DataAccess;
using TechnicalTask.Dto;

namespace TechnicalTask.Controllers;

[ApiController]
[Route("api/employees")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeesDataAccess _employeesDataAccess;

    public EmployeesController(IEmployeesDataAccess employeesDataAccess)
    {
        _employeesDataAccess = employeesDataAccess;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployees()
    {
        try
        {
            var employees = await _employeesDataAccess.GetEmployees(true);
            return Ok(employees);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{id}", Name = "EmployeeById")]
    public async Task<IActionResult> GetEmployee(int id)
    {
        try
        {
            var employee = await _employeesDataAccess.GetEmployee(id);
            if (employee == null)
                return NotFound();

            return Ok(employee);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateEmployee(EmployeeForCreationDto employee)
    {
        try
        {
            var createdEmployee = await _employeesDataAccess.CreateEmployee(employee);
            return CreatedAtRoute("EmployeeById", new { id = createdEmployee.Id }, createdEmployee);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(int id, EmployeeForUpdateDto employee)
    {
        try
        {
            var dbEmployee = await _employeesDataAccess.GetEmployee(id);
            if (dbEmployee == null)
                return NotFound();

            await _employeesDataAccess.UpdateEmployee(id, employee);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        try
        {
            var dbEmployee = await _employeesDataAccess.GetEmployee(id);
            if (dbEmployee == null)
                return NotFound();

            await _employeesDataAccess.RemoveEmployee(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
}