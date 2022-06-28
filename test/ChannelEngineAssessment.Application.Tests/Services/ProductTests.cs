using ChannelEngineAssessment.Application.Services;
using ChannelEngineAssessment.Core.Interfaces;
using ChannelEngineAssessment.Core.Repositories;
using Moq;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using ChannelEngineAssessment.Application.Tests.Builders;

namespace ChannelEngineAssessment.Application.Tests.Services
{
    public class ProductTests
    {
        // NOTE : This layer we are not loaded database objects, test functionality of application layer

        private Mock<IOrderRepository> _mockProductRepository;
        private Mock<IAppLogger<OrderService>> _mockAppLogger;
        private ProductBuilder ProductBuilder { get; } = new ProductBuilder();

        public ProductTests()
        {
            _mockProductRepository = new Mock<IOrderRepository>();
        }      

        [Fact]
        public async Task Get_Product_List()
        {

            var productService = new OrderService(_mockProductRepository.Object);
            var productList = await productService.GetProductByStatus("IN_PROGRESS");

            _mockProductRepository.Verify(x => x.GetorderByStatusAsync("staus"), Times.Once);
        }

        [Fact]
        public async Task Less_Than_Five_Product()
        {
            var productService = new OrderService(_mockProductRepository.Object);
            var productList = (await productService.GetProductByStatus("IN_PROGRESS"));

            Assert.True(productList.Count() < 5);

        }

        [Fact]
        public void Top_5_Product()
        {
            var list = ProductBuilder.GetProducts();
            var productService = new OrderService(_mockProductRepository.Object);
            var productList = productService.GetTop5Product(list);

            Assert.True(productList[0].TotalQuantity == list.Max(o => o.TotalQuantity));
            Assert.True(productList[productList.Count() -1].TotalQuantity == 10);
            Assert.True(productList.Count() == 5);

        }


    }
}
