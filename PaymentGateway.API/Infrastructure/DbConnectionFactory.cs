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
        string _connectionString = "Server=localhost,1434;Database=PaymentGatewayDockerDb;User Id=sa;Password=YourPassword123;TrustServerCertificate=True";
  

        return new SqlConnection(_connectionString);
    }
}
