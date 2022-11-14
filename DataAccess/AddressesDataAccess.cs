using System.Text;
using TechnicalTask.Models;

namespace TechnicalTask.DataAccess;

public class AddressesDataAccess : IAddressesDataAccess
{
    private readonly ISqlDataAccess _db;


    public AddressesDataAccess(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Address>> GetAddresses()
    {
        StringBuilder query = GetBaseEmployeeQuery();

        return (await _db.QueryAsync<Address>(query.ToString())).ToList();
    }

    private StringBuilder GetBaseEmployeeQuery()
    {
        return new StringBuilder(@"
                SELECT 
                Id, 
                City, 
                Country, 
                Address AS FullAddress, 
                PostCode 
            FROM Addresses");
    }
}