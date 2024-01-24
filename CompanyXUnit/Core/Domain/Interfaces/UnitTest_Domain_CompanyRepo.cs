using GatewayDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using CompanyDomain.Exception;
using CompanyXUnit.Core.Domain.Shared;
using CompanyDomain.Entities;

namespace CompanyXUnit.Core.Domain.Interfaces
{
    public class UnitTest_Domain_CompanyRepo:MockedEntities
    {
        private readonly Mock<ICompanyRepository> _mock;
        public UnitTest_Domain_CompanyRepo()
        {
            _mock = new Mock<ICompanyRepository>();
        }

        [Fact]
        public async Task Domain_Company_Test_AddAsync_Method()
        {

            //Arrange
            _mock.Setup(repo => repo.AddAsync(It.IsAny<Companyy>())).ReturnsAsync(await Result<Companyy>.Success("Added Successfully"));

            //Acting
            ICompanyRepository companyRepository = _mock.Object;
            var actualed_value = await companyRepository.AddAsync(company);

            //Asserting
            Assert.NotNull(actualed_value);
        }

        [Fact]
        public async Task Domain_Company_Test_GetAllAsync_Method()
        {

            //Arrange
            //_mock.Setup(repo => repo.AddAsync(It.IsAny<Company>())).ReturnsAsync(await Result<Company>.Success("Added Successfully"));
            _mock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(await Result<IEnumerable<Companyy>>.Success("View Successfully"));

            //Acting
            ICompanyRepository companyRepository = _mock.Object;
            var actualed_value = await companyRepository.GetAllAsync();

            //Asserting
            Assert.NotNull(actualed_value);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        public async Task Domain_Company_Test_GetByIdAsync_Method(int id)
        {

            //Arrange
            _mock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(await Result<Companyy>.Failure("View Successfully"));

            //Acting
            ICompanyRepository companyRepository = _mock.Object;
            var actualed_value = await companyRepository.GetByIdAsync(id);

            //Asserting

            _mock.Verify(r => r.GetByIdAsync(id), Times.Once());
            Assert.NotNull(actualed_value);

           
            Assert.False(actualed_value.IsFailure);
        }
        [Fact]
        public async Task Domain_Company_Test_UpdateAsync_Method()
        {

            //Arrange
            _mock.Setup(repo => repo.UpdateAsync(It.IsAny<Companyy>())).ReturnsAsync(await Result<Companyy>.Success("Update Successfully"));

            //Acting
            ICompanyRepository companyRepository = _mock.Object;
            var actualed_value = await companyRepository.UpdateAsync(company);

            //Asserting
            Assert.NotNull(actualed_value);
        }
        [Fact]
        public async Task Domain_Company_Test_DeleteAsync_Method()
        {

            //Arrange
            _mock.Setup(repo => repo.DeleteAsync(It.IsAny<Companyy>())).ReturnsAsync(await Result<Companyy>.Success("Update Successfully"));

            //Acting
            ICompanyRepository companyRepository = _mock.Object;
            var actualed_value = await companyRepository.DeleteAsync(company);

            //Asserting
            Assert.NotNull(actualed_value);
            _mock.Verify();


        }
        [Fact]
        public async Task Domain_Company_Test_GetByCodeAsync_Method()
        {
            string code = "";
            //Arrange
            //_mock.Setup(repo => repo.AddAsync(It.IsAny<Company>())).ReturnsAsync(await Result<Company>.Success("Added Successfully"));
            _mock.Setup(repo => repo.GetByCodeAsync(code)).ReturnsAsync(await Result<Companyy>.Success("View Successfully"));

            //Acting
            ICompanyRepository companyRepository = _mock.Object;
            var actualed_value = await companyRepository.GetByCodeAsync(code);

            //Asserting
            Assert.NotNull(actualed_value);
            Assert.True(actualed_value.IsSuccess);

        }

    }
}
