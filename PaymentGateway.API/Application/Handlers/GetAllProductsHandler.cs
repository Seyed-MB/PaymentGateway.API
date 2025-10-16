using Dapper;
using MediatR;
using PaymentGateway.Domain.Entities;
 

namespace PaymentGateway.Application.Handlers;

public record GetAllProductsQuery() : IRequest<IEnumerable<Product>>;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
{
    private readonly IDapperRepository _db;

    public GetAllProductsHandler(IDapperRepository db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        const string sql = "SELECT Id, Name, Price FROM Products";
        using var connection = _db.CreateConnection();
        var products = await connection.QueryAsync<Product>(sql);
        return products;
    }
}
