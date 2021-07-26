using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;

namespace Tests
{
    [TestClass]
    public class ProductServiceTest
    {
        [TestMethod]
        public async Task ProductService_Can_Return_ProductList()
        {
            // Arrange 
            var options = new DbContextOptionsBuilder<AdventureWorks2019Context>()
                .UseInMemoryDatabase(databaseName: "Adventure Works")
                .Options;
            var context = new AdventureWorks2019Context(options);
            var productList = ContextSetupForTest.GetEntities<Product>();
            await context.AddRangeAsync(productList);
            await context.SaveChangesAsync();

            var productRepo = new ProductRepo(context);

            // Act
            var products = (List<Product>) await productRepo.FindAll();

            // Assert
            var expectedProductCount = 501;
            var expectedName = "Adjustable Race";
            var expectedProductNumber = "AR-5381";

            Assert.AreEqual(expectedProductCount, products.Count);
            Assert.AreEqual(expectedName, products[0].Name);
            Assert.AreEqual(expectedProductNumber, products[0].ProductNumber);            
        }
    }
}