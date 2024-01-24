using Moq;
using CompanyDomain.Exception;
using CompanyXUnit.Core.Domain.Shared;
using GatewayDomain.Interfaces;
using Company.Domain.Repositories;
using CompanyDomain.Entities;

namespace ServiceXUnit.Core.Domain.Interfaces
{
    public class UnitTest_Domain_ServiceRepo:MockedEntities
    {
        private readonly Mock<IServiceRepository> _mock;
        public UnitTest_Domain_ServiceRepo()
        {
            _mock = new Mock<IServiceRepository>();
        }

        [Fact]
        public async Task Domain_Service_Test_AddAsync_Method()
        {

            //Arrange
            _mock.Setup(repo => repo.AddAsync(It.IsAny<Service>())).ReturnsAsync(await Result<Service>.Success("Added Successfully"));

            //Acting
            IServiceRepository ServiceRepository = _mock.Object;
            var actualed_value = await ServiceRepository.AddAsync(service);

            //Asserting
            Assert.NotNull(actualed_value);
        }

        [Fact]
        public async Task Domain_Service_Test_GetAllAsync_Method()
        {

            //Arrange
            //_mock.Setup(repo => repo.AddAsync(It.IsAny<Service>())).ReturnsAsync(await Result<Service>.Success("Added Successfully"));
            _mock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(await Result<IEnumerable<Service>>.Success("View Successfully"));

            //Acting
            IServiceRepository ServiceRepository = _mock.Object;
            var actualed_value = await ServiceRepository.GetAllAsync();

            //Asserting
            Assert.NotNull(actualed_value);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        public async Task Domain_Service_Test_GetByIdAsync_Method(int id)
        {

            //Arrange
            _mock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(await Result<Service>.Failure("View Successfully"));

            //Acting
            IServiceRepository ServiceRepository = _mock.Object;
            var actualed_value = await ServiceRepository.GetByIdAsync(id);

            //Asserting

            _mock.Verify(r => r.GetByIdAsync(id), Times.Once());
            Assert.NotNull(actualed_value);


            Assert.False(actualed_value.IsFailure);
        }
        [Fact]
        public async Task Domain_Service_Test_UpdateAsync_Method()
        {

            //Arrange
            _mock.Setup(repo => repo.UpdateAsync(It.IsAny<Service>())).ReturnsAsync(await Result<Service>.Success("Update Successfully"));

            //Acting
            IServiceRepository ServiceRepository = _mock.Object;
            var actualed_value = await ServiceRepository.UpdateAsync(service);

            //Asserting
            Assert.NotNull(actualed_value);
        }
        [Fact]
        public async Task Domain_Service_Test_DeleteAsync_Method()
        {

            //Arrange
            _mock.Setup(repo => repo.DeleteAsync(It.IsAny<Service>())).ReturnsAsync(await Result<Service>.Success("Update Successfully"));

            //Acting
            IServiceRepository ServiceRepository = _mock.Object;
            var actualed_value = await ServiceRepository.DeleteAsync(service);

            //Asserting
            Assert.NotNull(actualed_value);
            _mock.Verify();


        }

       
        [Theory]
        [InlineData("se342")]
        [InlineData("123321")]
        public async Task Domain_Service_Test_GetByCodeAsync_Method(string code)
        {
           
            //Arrange
            //_mock.Setup(repo => repo.AddAsync(It.IsAny<Service>())).ReturnsAsync(await Result<Service>.Success("Added Successfully"));
            _mock.Setup(repo => repo.GetByCodeAsync(code)).ReturnsAsync(await Result<Service>.Success("View Successfully"));

            //Acting
            IServiceRepository ServiceRepository = _mock.Object;
            var actualed_value = await ServiceRepository.GetByCodeAsync(code);

            //Asserting
            Assert.NotNull(actualed_value);
            Assert.True(actualed_value.IsSuccess);

        }
    }
}
