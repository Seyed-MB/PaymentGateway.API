using System.Data;

namespace PaymentGateway.Infrastructure;

public interface IDapperRepository
{
    IDbConnection CreateConnection();
}