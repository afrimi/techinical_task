using System.Text;
using TechnicalTask.Dto;
using TechnicalTask.Models;

namespace TechnicalTask.DataAccess;

public class EmployeesDataAccess : IEmployeesDataAccess
{
    private readonly ISqlDataAccess _db;


    public EmployeesDataAccess(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Employee>> GetEmployees(bool activeOnly)
    {
        StringBuilder query = GetBaseEmployeeQuery();

        if (activeOnly)
        {
            query.Append(" AND IsActive = 1");
        }

        return (await _db.QueryAsync<Employee>(query.ToString())).ToList();
    }

    public async Task<Employee> GetEmployee(int id)
    {
        StringBuilder query = GetBaseEmployeeQuery();

        query.Append(" AND Id = @Id AND IsActive = 1");

        return await _db.QuerySingleOrDefaultAsync<Employee>(query.ToString(), new { id });
    }

    public async Task<Employee> CreateEmployee(EmployeeForCreationDto employee)
    {
        string query = @"
                INSERT INTO Employees (Name, Age, AddressId, PositionId)
                    VALUES (@Name, @Age, @AddressId, @PositionId)
                SELECT CAST(SCOPE_IDENTITY() as int)";

        var id = await _db.QuerySingleAsync<int>(
            query,
            new
            {
                Name = employee.Name,
                Age = employee.Age,
                AddressId = employee.AddressId,
                PositionId = employee.PositionId
            });

        var createdEmployee = new Employee
        {
            Id = id,
            Name = employee.Name,
            Age = employee.Age,
            AddressId = employee.AddressId,
            PositionId = employee.PositionId
        };

        return createdEmployee;
    }

    public async Task UpdateEmployee(int id, EmployeeForUpdateDto employee)
    {
        var query = "UPDATE Employees SET Name = @Name, Age = @Age, AddressId = @AddressId, PositionId = @PositionId WHERE Id = @Id";

        await _db.ExecuteAsync(query, new
        {
            Id = id,
            Name = employee.Name,
            Age = employee.Age,
            AddressId = employee.AddressId,
            PositionId = employee.PositionId
        });
    }

    public async Task RemoveEmployee(int id)
    {
        string query = @"
                UPDATE Employees
                SET LeavingTimeUtc = @LeavingTimeUtc,
                    IsActive = @IsActive
                WHERE Id = @Id
                    AND LeavingTimeUtc IS NULL";

        await _db.ExecuteAsync(
            query,
            new
            {
                LeavingTimeUtc = DateTime.UtcNow,
                IsActive = false,
                Id = id
            });
    }
    
    private StringBuilder GetBaseEmployeeQuery()
    {
        return new StringBuilder(@"
                SELECT 
                Id, 
                Name, 
                Age, 
                AddressId, 
                PositionId, 
                SigningTimeUtc, 
                LeavingTimeUtc, 
                IsActive 
            FROM Employees
            WHERE 1 = 1");
    }
}