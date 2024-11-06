using AutoFixture.Xunit2;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiDunnhumbyAssessment.Controllers;
using WebApiDunnhumbyAssessment.Entities;

namespace WebApiDunnhumbyAssessment.UnitTests.Controllers
{
    public class ProductsControllerTests : IDisposable
    {
        public readonly ProductDbContext context;
        private readonly ProductsController productsController;

        public ProductsControllerTests()
        {
            var options = new DbContextOptionsBuilder<ProductDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) 
                .Options;

            context = new ProductDbContext(options);

            productsController = new ProductsController(context);
        }

        [Theory, AutoData]
        public async Task GetProducts_ShouldReturnListProducts(IEnumerable<Product> products)
        {
            context.Products.AddRange(products);
            await context.SaveChangesAsync();

            var result = await productsController.Get();

            result.Count().Should().Be(products.Count());
        }

        [Theory, AutoData]
        public async Task CreateProducts_ShouldReturnCreatedAtActionResult(Product product)
        {   
            var result = await productsController.Create(product);
            var actionResult = result.Should().BeOfType<ActionResult<Product>>().Subject;

            var createdAtActionResult = actionResult.Result.Should().BeOfType<CreatedAtActionResult>().Subject;
            var createdProduct = createdAtActionResult.Value.Should().BeOfType<Product>().Subject;

            createdProduct.Id.Should().Be(product.Id);
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}