using Moq;
using CompanyDomain.Entities;
using CompanyDomain.Exception;
using CompanyXUnit.Core.Domain.Shared;
using GatewayDomain.Interfaces;
using Company.Domain.Repositories;

namespace CompanyXUnit.Core.Domain.Interfaces
{
    public class UnitTest_Domain_ProviderRepo:MockedEntities
    {
        private readonly Mock<IProviderRepository> _mock;
        public UnitTest_Domain_ProviderRepo()
        {
            _mock = new Mock<IProviderRepository>();
        }

        [Fact]
        public async Task Domain_Provider_Test_AddAsync_Method()
        {

            //Arrange
            _mock.Setup(repo => repo.AddAsync(It.IsAny<Provider>())).ReturnsAsync(await Result<Provider>.Success("Added Successfully"));

            //Acting
            IProviderRepository ProviderRepository = _mock.Object;
            var actualed_value = await ProviderRepository.AddAsync(provider);

            //Asserting
            Assert.NotNull(actualed_value);
        }

        [Fact]
        public async Task Domain_Provider_Test_GetAllAsync_Method()
        {

            //Arrange
            //_mock.Setup(repo => repo.AddAsync(It.IsAny<Provider>())).ReturnsAsync(await Result<Provider>.Success("Added Successfully"));
            _mock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(await Result<IEnumerable<Provider>>.Success("View Successfully"));

            //Acting
            IProviderRepository ProviderRepository = _mock.Object;
            var actualed_value = await ProviderRepository.GetAllAsync();

            //Asserting
            Assert.NotNull(actualed_value);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        public async Task Domain_Provider_Test_GetByIdAsync_Method(int id)
        {

            //Arrange
            _mock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(await Result<Provider>.Failure("View Successfully"));

            //Acting
            IProviderRepository ProviderRepository = _mock.Object;
            var actualed_value = await ProviderRepository.GetByIdAsync(id);

            //Asserting

            _mock.Verify(r => r.GetByIdAsync(id), Times.Once());
            Assert.NotNull(actualed_value);


            Assert.False(actualed_value.IsFailure);
        }

        [Fact]
        public async Task Domain_Provider_Test_UpdateAsync_Method()
        {

            //Arrange
            _mock.Setup(repo => repo.UpdateAsync(It.IsAny<Provider>())).ReturnsAsync(await Result<Provider>.Success("Update Successfully"));

            //Acting
            IProviderRepository ProviderRepository = _mock.Object;
            var actualed_value = await ProviderRepository.UpdateAsync(provider);

            //Asserting
            Assert.NotNull(actualed_value);
        }
        [Fact]
        public async Task Domain_Provider_Test_DeleteAsync_Method()
        {

            //Arrange
            _mock.Setup(repo => repo.DeleteAsync(It.IsAny<Provider>())).ReturnsAsync(await Result<Provider>.Success("Update Successfully"));

            //Acting
            IProviderRepository ProviderRepository = _mock.Object;
            var actualed_value = await ProviderRepository.DeleteAsync(provider);

            //Asserting
            Assert.NotNull(actualed_value);
            _mock.Verify();


        }

        [Fact]
        public async Task Domain_Provider_Test_GetByCodeAsync_Method()
        {
            string code = "";
            //Arrange
            //_mock.Setup(repo => repo.AddAsync(It.IsAny<Provider>())).ReturnsAsync(await Result<Provider>.Success("Added Successfully"));
            _mock.Setup(repo => repo.GetByCodeAsync(code)).ReturnsAsync(await Result<Provider>.Success("View Successfully"));

            //Acting
            IProviderRepository ProviderRepository = _mock.Object;
            var actualed_value = await ProviderRepository.GetByCodeAsync(code);

            //Asserting
            Assert.NotNull(actualed_value);
            Assert.True(actualed_value.IsSuccess);

        }
    }
}
