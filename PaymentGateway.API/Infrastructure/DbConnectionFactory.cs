using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

public class DbConnectionFactory : IDapperRepository
{
    private readonly IConfiguration _configuration;
    private readonly string _defaultConnectionString =
        "Server=sqlserver-service,1433;Database=PaymentGatewayDockerDb;User Id=sa;Password=YourPassword123;TrustServerCertificate=True";

    public DbConnectionFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection CreateConnection()
    {
        // ابتدا تلاش می‌کنیم کانکشن استرینگ را از IConfiguration بخوانیم
        string connectionString = _configuration.GetConnectionString("DefaultConnection")
                                  ?? _defaultConnectionString;

        var connection = new SqlConnection(connectionString);

        try
        {
            connection.Open(); // اتصال را باز می‌کنیم
        }
        catch (SqlException ex)
        {
            // خطای login یا اتصال را لاگ می‌کنیم
            Console.WriteLine($"Failed to open SQL connection: {ex.Message}");
            throw;
        }

        return connection;
    }
}
