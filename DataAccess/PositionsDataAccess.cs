using System.Text;
using TechnicalTask.Models;

namespace TechnicalTask.DataAccess;

public class PositionsDataAccess : IPositionsDataAccess
{
    private readonly ISqlDataAccess _db;


    public PositionsDataAccess(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Position>> GetPositions()
    {
        string query = "SELECT Id, Name FROM Positions";

        return (await _db.QueryAsync<Position>(query)).ToList();
    }
}