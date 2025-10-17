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
        //string _connectionString = "Server=localhost,1434;Database=PaymentGatewayDockerDb;User Id=sa;Password=YourPassword123;TrustServerCertificate=True";
        string _connectionString = "Server=sqlserver-service,1433;Database=PaymentGatewayDockerDb;User Id=sa;Password=YourPassword123;TrustServerCertificate=True";
        return new SqlConnection(_connectionString);

        //return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

        //return new SqlConnection(_connectionString);
    }
}
