using Dapper;
namespace PaymentGateway.Application.Handlers;
public class ProductRepository : IProductRepository
{
    private readonly IDapperRepository _dapper;

    public ProductRepository(IDapperRepository dapper)
    {
        _dapper = dapper;
    }

    public async Task<int> InsertProductAsync(string name, decimal price)
    {
        using var connection = _dapper.CreateConnection();
        var sql = "INSERT INTO Products (Name, Price) VALUES (@Name, @Price); SELECT CAST(SCOPE_IDENTITY() as int)";
        return await connection.QuerySingleAsync<int>(sql, new { Name = name, Price = price });
    }
}


