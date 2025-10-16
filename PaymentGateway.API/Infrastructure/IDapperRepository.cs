using System.Data;

public interface IDapperRepository
{
    IDbConnection CreateConnection();
}