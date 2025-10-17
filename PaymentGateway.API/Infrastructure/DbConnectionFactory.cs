using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

public class DbConnectionFactory : IDapperRepository
{
    private readonly IConfiguration _configuration;

    public DbConnectionFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection CreateConnection()
    {
       string _connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");
        return new SqlConnection(_configuration.GetConnectionString(_connectionString));
    }
}
