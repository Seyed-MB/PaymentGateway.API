using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

public class DapperRepository : IDapperRepository
{
    private readonly IConfiguration _configuration;

    public DapperRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection CreateConnection()
    {
        return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
    }
}
