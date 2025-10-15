using Xunit;
using Moq;
using Microsoft.Extensions.Configuration;
using PaymentGateway.Application.Handlers;
using PaymentGateway.Application.Models;

namespace PaymentGateway.Tests.Handlers
{
    public class CreateProductHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldInsertProductAndReturnId()
        {
            // Arrange
            var inMemorySettings = new Dictionary<string, string> {
                {"ConnectionStrings:DefaultConnection", "Server=localhost;Database=PaymentGatewayDB;User Id=sa;Password=123456;TrustServerCertificate=True;"}
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            var handler = new CreateProductHandler(configuration);

            var command = new CreateProductCommand
            {
                Name = "Test Product",
                Price = 12345
            };

            // Act
            var result = await handler.Handle(command, default);

            // Assert
            Assert.True(result > 0);
        }
    }
}
