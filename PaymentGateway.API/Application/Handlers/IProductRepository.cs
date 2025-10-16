namespace PaymentGateway.Application.Handlers;
public interface IProductRepository
{
    Task<int> InsertProductAsync(string name, decimal price);
}