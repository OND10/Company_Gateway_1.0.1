using Moq;
using CompanyDomain.Entities;
using CompanyDomain.Exception;
using CompanyXUnit.Core.Domain.Shared;
using GatewayDomain.Interfaces;
using Company.Domain.Repositories;

namespace CompanyXUnit.Core.Domain.Interfaces
{
    public class UnitTest_Domain_ProductRepo:MockedEntities
    {
        private readonly Mock<IProductRepository> _mock;
        public UnitTest_Domain_ProductRepo()
        {
            _mock = new Mock<IProductRepository>();
        }

        [Fact]
        public async Task Domain_Product_Test_AddAsync_Method()
        {

            //Arrange
            _mock.Setup(repo => repo.AddAsync(It.IsAny<Product>())).ReturnsAsync(await Result<Product>.Success("Added Successfully"));

            //Acting
            IProductRepository ProductRepository = _mock.Object;
            var actualed_value = await ProductRepository.AddAsync(products);

            //Asserting
            Assert.NotNull(actualed_value);
        }

        [Fact]
        public async Task Domain_Product_Test_GetAllAsync_Method()
        {

            //Arrange
            //_mock.Setup(repo => repo.AddAsync(It.IsAny<Product>())).ReturnsAsync(await Result<Product>.Success("Added Successfully"));
            _mock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(await Result<IEnumerable<Product>>.Success("View Successfully"));

            //Acting
            IProductRepository ProductRepository = _mock.Object;
            var actualed_value = await ProductRepository.GetAllAsync();

            //Asserting
            Assert.NotNull(actualed_value);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        public async Task Domain_Product_Test_GetByIdAsync_Method(int id)
        {

            //Arrange
            _mock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(await Result<Product>.Failure("View Successfully"));

            //Acting
            IProductRepository ProductRepository = _mock.Object;
            var actualed_value = await ProductRepository.GetByIdAsync(id);

            //Asserting

            _mock.Verify(r => r.GetByIdAsync(id), Times.Once());
            Assert.NotNull(actualed_value);


            Assert.False(actualed_value.IsFailure);
        }
        [Fact]
        public async Task Domain_Product_Test_UpdateAsync_Method()
        {

            //Arrange
            _mock.Setup(repo => repo.UpdateAsync(It.IsAny<Product>())).ReturnsAsync(await Result<Product>.Success("Update Successfully"));

            //Acting
            IProductRepository ProductRepository = _mock.Object;
            var actualed_value = await ProductRepository.UpdateAsync(products);

            //Asserting
            Assert.NotNull(actualed_value);
        }
        [Fact]
        public async Task Domain_Product_Test_DeleteAsync_Method()
        {

            //Arrange
            _mock.Setup(repo => repo.DeleteAsync(It.IsAny<Product>())).ReturnsAsync(await Result<Product>.Success("Update Successfully"));

            //Acting
            IProductRepository ProductRepository = _mock.Object;
            var actualed_value = await ProductRepository.DeleteAsync(products);

            //Asserting
            Assert.NotNull(actualed_value);
            _mock.Verify();


        }
        [Fact]
        public async Task Domain_Product_Test_GetByCodeAsync_Method()
        {
            string code = "";
            //Arrange
            //_mock.Setup(repo => repo.AddAsync(It.IsAny<Product>())).ReturnsAsync(await Result<Product>.Success("Added Successfully"));
            _mock.Setup(repo => repo.GetByCodeAsync(code)).ReturnsAsync(await Result<Product>.Success("View Successfully"));

            //Acting
            IProductRepository ProductRepository = _mock.Object;
            var actualed_value = await ProductRepository.GetByCodeAsync(code);

            //Asserting
            Assert.NotNull(actualed_value);
            Assert.True(actualed_value.IsSuccess);

        }
    }
}
