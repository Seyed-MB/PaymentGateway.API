using Microsoft.Extensions.Configuration;
using PaymentGateway.Application.Models;
using PaymentGateway.Application.Handlers;
 
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

public class CreateProductHandlerTests
{
    [Fact]
    public async Task Handle_ShouldInsertProductAndReturnId()
    {
        // Arrange
        var inMemorySettings = new Dictionary<string, string> {
            {"ConnectionStrings:DefaultConnection", "Server=localhost,1434;Database=PaymentGatewayDockerDb;User Id=sa;Password=YourPassword123;TrustServerCertificate=True;"}
        };

        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();

        IDapperRepository repository = new DbConnectionFactory(configuration); // توجه: نوع Interface
        var handler = new CreateProductHandler(repository);

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
