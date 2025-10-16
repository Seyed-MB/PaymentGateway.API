using Microsoft.Extensions.Configuration;
using PaymentGateway.Application.Models;
using PaymentGateway.Application.Handlers;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Moq;
using System.Data;
using Moq.Dapper;
 
public class CreateProductHandlerTests
{
    [Fact]
    public async Task Handle_ShouldInsertProductAndReturnId()
    {
        // Arrange
        var command = new CreateProductCommand
        {
            Name = "Test Product",
            Price = 12345
        };

        var mockRepo = new Mock<IProductRepository>();
        mockRepo.Setup(r => r.InsertProductAsync(It.IsAny<string>(), It.IsAny<decimal>()))
                .ReturnsAsync(1);

        var handler = new CreateProductHandler(mockRepo.Object);


        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Equal(1, result);
    }


}
