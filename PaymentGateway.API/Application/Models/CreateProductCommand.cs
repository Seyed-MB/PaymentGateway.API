using MediatR;

namespace PaymentGateway.Application.Models
{
    // Command برای ایجاد محصول
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
