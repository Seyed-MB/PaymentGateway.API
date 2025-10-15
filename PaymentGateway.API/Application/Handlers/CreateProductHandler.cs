using Dapper;
using MediatR;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Infrastructure;

namespace PaymentGateway.Application.Handlers;

public record CreateProductCommand(string Name, decimal Price) : IRequest<int>;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IDapperRepository _db;

    public CreateProductHandler(IDapperRepository db)
    {
        _db = db;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        const string sql = "INSERT INTO Products (Name, Price) VALUES (@Name, @Price); SELECT CAST(SCOPE_IDENTITY() as int);";
        using var connection = _db.CreateConnection();
        var id = await connection.QuerySingleAsync<int>(sql, new { request.Name, request.Price });
        return id;
    }
}
