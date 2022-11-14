using TechnicalTask.Models;

namespace TechnicalTask.DataAccess;

public interface IPositionsDataAccess
{
    Task<IEnumerable<Position>> GetPositions();
}