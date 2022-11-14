using TechnicalTask.Models;

namespace TechnicalTask.DataAccess;

public interface IAddressesDataAccess
{
    Task<IEnumerable<Address>> GetAddresses();
}