using Dapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PaymentGateway.Application.Models;
 
using System.Data;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IDapperRepository _repository;

    public CreateProductHandler(IDapperRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        using IDbConnection connection = _repository.CreateConnection();
        var sql = "INSERT INTO Products (Name, Price) VALUES (@Name, @Price); SELECT CAST(SCOPE_IDENTITY() as int)";
        return await connection.QuerySingleAsync<int>(sql, new { request.Name, request.Price });
    }
}
