using TechnicalTask.Dto;
using TechnicalTask.Models;

namespace TechnicalTask.DataAccess;

public interface IEmployeesDataAccess
{
    Task<IEnumerable<Employee>> GetEmployees(bool activeOnly);
    Task<Employee> GetEmployee(int id);
    Task<Employee> CreateEmployee(EmployeeForCreationDto employee);
    Task UpdateEmployee(int id, EmployeeForUpdateDto employee);
    Task RemoveEmployee(int id);
}