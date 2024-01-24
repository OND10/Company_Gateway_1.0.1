using Moq;
using CompanyDomain.Exception;
using CompanyXUnit.Core.Domain.Shared;
using GatewayDomain.Interfaces;
using CompanyDomain.Entities;
using Company.Domain.Repositories;

namespace CompanyXUnit.Core.Domain.Interfaces
{
    public class UnitTest_Domain_LocationRepo:MockedEntities
    {
        private readonly Mock<ILocationRepository> _mock;
        public UnitTest_Domain_LocationRepo()
        {
            _mock = new Mock<ILocationRepository>();
        }

        [Fact]
        public async Task Domain_Location_Test_AddAsync_Method()
        {

            //Arrange
            _mock.Setup(repo => repo.AddAsync(It.IsAny<Location>())).ReturnsAsync(await Result<Location>.Success("Added Successfully"));

            //Acting
            ILocationRepository LocationRepository = _mock.Object;
            var actualed_value = await LocationRepository.AddAsync(location);

            //Asserting
            Assert.NotNull(actualed_value);
        }

        [Fact]
        public async Task Domain_Location_Test_GetAllAsync_Method()
        {

            //Arrange
            //_mock.Setup(repo => repo.AddAsync(It.IsAny<Location>())).ReturnsAsync(await Result<Location>.Success("Added Successfully"));
            _mock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(await Result<IEnumerable<Location>>.Success("View Successfully"));

            //Acting
            ILocationRepository LocationRepository = _mock.Object;
            var actualed_value = await LocationRepository.GetAllAsync();

            //Asserting
            Assert.NotNull(actualed_value);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        public async Task Domain_Location_Test_GetByIdAsync_Method(int id)
        {

            //Arrange
            _mock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(await Result<Location>.Failure("View Successfully"));

            //Acting
            ILocationRepository LocationRepository = _mock.Object;
            var actualed_value = await LocationRepository.GetByIdAsync(id);

            //Asserting

            _mock.Verify(r => r.GetByIdAsync(id), Times.Once());
            Assert.NotNull(actualed_value);


            Assert.False(actualed_value.IsFailure);
        }
        [Fact]
        public async Task Domain_Location_Test_UpdateAsync_Method()
        {

            //Arrange
            _mock.Setup(repo => repo.UpdateAsync(It.IsAny<Location>())).ReturnsAsync(await Result<Location>.Success("Update Successfully"));

            //Acting
            ILocationRepository LocationRepository = _mock.Object;
            var actualed_value = await LocationRepository.UpdateAsync(location);

            //Asserting
            Assert.NotNull(actualed_value);
        }
        [Fact]
        public async Task Domain_Location_Test_DeleteAsync_Method()
        {

            //Arrange
            _mock.Setup(repo => repo.DeleteAsync(It.IsAny<Location>())).ReturnsAsync(await Result<Location>.Success("Update Successfully"));

            //Acting
            ILocationRepository LocationRepository = _mock.Object;
            var actualed_value = await LocationRepository.DeleteAsync(location);

            //Asserting
            Assert.NotNull(actualed_value);
            _mock.Verify();


        }
        [Fact]
        public async Task Domain_Location_Test_GetByCodeAsync_Method()
        {
            string code = "";
            //Arrange
            //_mock.Setup(repo => repo.AddAsync(It.IsAny<Location>())).ReturnsAsync(await Result<Location>.Success("Added Successfully"));
            _mock.Setup(repo => repo.GetByCodeAsync(code)).ReturnsAsync(await Result<Location>.Success("View Successfully"));

            //Acting
            ILocationRepository LocationRepository = _mock.Object;
            var actualed_value = await LocationRepository.GetByCodeAsync(code);

            //Asserting
            Assert.NotNull(actualed_value);
            Assert.True(actualed_value.IsSuccess);

        }
    }
}
