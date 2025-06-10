using Xunit;
using FluentAssertions;
using Moq;
using TiendaMVC.Controllers;
using TiendaMVC.Models; 
using TiendaMVC.Services;
using Microsoft.AspNetCore.Mvc;


public class ProductosControllerTest
{
    [Fact]
    public async Task Index_ReturnsViewWithProductList()
    {
        var mockAPI = new Mock<ApiClient>();
        mockAPI.Setup(s => s.GetProductsAsync())
               .ReturnsAsync(new List<Product>
               {
                   new Product { Id = 1, Nombre = "Iphone 16 Pro Max", Precio = 10.0m }
               });

        var moqObj = new ProductosController(mockAPI.Object);

        var result = await moqObj.Index();

        // Assert
        result.Should().BeOfType<ViewResult>()
              .Which.Model.Should().BeAssignableTo<IEnumerable<Product>>()
              .And.As<IEnumerable<Product>>()
              .Should().HaveCount(1);
    }


}  