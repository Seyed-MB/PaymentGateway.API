using MediatR;
using PaymentGateway.Application.Handlers;
using PaymentGateway.Application.Models;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IProductRepository _repository;

    public CreateProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // مستقیماً از سرویس استفاده می‌کنیم
        return await _repository.InsertProductAsync(request.Name, request.Price);
    }
}
