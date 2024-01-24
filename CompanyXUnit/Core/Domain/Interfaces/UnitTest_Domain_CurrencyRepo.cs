using Moq;
using CompanyDomain.Entities;
using CompanyDomain.Exception;
using CompanyXUnit.Core.Domain.Shared;
using GatewayDomain.Interfaces;


namespace CurrencyXUnit.Core.Domain.Interfaces
{
    public class UnitTest_Domain_CurrencyRepo : MockedEntities
    {
        private readonly Mock<ICurrencyRepository> _mock;
        public UnitTest_Domain_CurrencyRepo()
        {
            _mock = new Mock<ICurrencyRepository>();
        }

        [Fact]
        public async Task Domain_Currency_Test_AddAsync_Method()
        {

            //Arrange
            _mock.Setup(repo => repo.AddAsync(It.IsAny<Currency>())).ReturnsAsync(await Result<Currency>.Success("Added Successfully"));

            //Acting
            ICurrencyRepository CurrencyRepository = _mock.Object;
            var actualed_value = await CurrencyRepository.AddAsync(currency);

            //Asserting
            Assert.NotNull(actualed_value);
        }

        [Fact]
        public async Task Domain_Currency_Test_GetAllAsync_Method()
        {

            //Arrange
            //_mock.Setup(repo => repo.AddAsync(It.IsAny<Currency>())).ReturnsAsync(await Result<Currency>.Success("Added Successfully"));
            _mock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(await Result<IEnumerable<Currency>>.Success("View Successfully"));

            //Acting
            ICurrencyRepository CurrencyRepository = _mock.Object;
            var actualed_value = await CurrencyRepository.GetAllAsync();

            //Asserting
            Assert.NotNull(actualed_value);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        public async Task Domain_Currency_Test_GetByIdAsync_Method(int id)
        {

            //Arrange
            _mock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(await Result<Currency>.Failure("View Successfully"));

            //Acting
            ICurrencyRepository CurrencyRepository = _mock.Object;
            var actualed_value = await CurrencyRepository.GetByIdAsync(id);

            //Asserting

            _mock.Verify(r => r.GetByIdAsync(id), Times.Once());
            Assert.NotNull(actualed_value);


            Assert.False(actualed_value.IsFailure);
        }
        [Fact]
        public async Task Domain_Currency_Test_UpdateAsync_Method()
        {

            //Arrange
            _mock.Setup(repo => repo.UpdateAsync(It.IsAny<Currency>())).ReturnsAsync(await Result<Currency>.Success("Update Successfully"));

            //Acting
            ICurrencyRepository CurrencyRepository = _mock.Object;
            var actualed_value = await CurrencyRepository.UpdateAsync(currency);

            //Asserting
            Assert.NotNull(actualed_value);
        }
        [Fact]
        public async Task Domain_Currency_Test_DeleteAsync_Method()
        {

            //Arrange
            _mock.Setup(repo => repo.DeleteAsync(It.IsAny<Currency>())).ReturnsAsync(await Result<Currency>.Success("Update Successfully"));

            //Acting
            ICurrencyRepository CurrencyRepository = _mock.Object;
            var actualed_value = await CurrencyRepository.DeleteAsync(currency);

            //Asserting
            Assert.NotNull(actualed_value);
            _mock.Verify();


        }
        [Fact]
        public async Task Domain_Currency_Test_GetByCodeAsync_Method()
        {
            string code = "";
            //Arrange
            //_mock.Setup(repo => repo.AddAsync(It.IsAny<Currency>())).ReturnsAsync(await Result<Currency>.Success("Added Successfully"));
            _mock.Setup(repo => repo.GetByCodeAsync(code)).ReturnsAsync(await Result<Currency>.Success("View Successfully"));

            //Acting
            ICurrencyRepository CurrencyRepository = _mock.Object;
            var actualed_value = await CurrencyRepository.GetByCodeAsync(code);

            //Asserting
            Assert.NotNull(actualed_value);
            Assert.True(actualed_value.IsSuccess);

        }
    }
}
