using CompanyXUnit.Core.Domain.Shared;
using GatewayDomain.Common;
using CompanyDomain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyXUnit.Core.Domain
{
    public class UnitTest_Domain_Currency_Properties_Validation
    {
        private readonly Mock<IUnitofTest> _Utest;
        public UnitTest_Domain_Currency_Properties_Validation()
        {
            _Utest = new Mock<IUnitofTest>();
        }

        [Theory]
        [InlineData("TharwatCompany")]
        public async Task Domain_Currency_English_Name_Validation_Test_Method(string defaultname)
        {
            //Arrange
            Currency currency = new Currency();
            _Utest.Setup(demo => demo.baseValidation.Namevalidate()).ReturnsAsync(await currency.Namevalidate());

            //Acting
            IUnitofTest baseValidation = _Utest.Object;
            var actualed_value = baseValidation.baseValidation.Namevalidate();

            //Asserting
            Assert.NotNull(actualed_value);
            Assert.Matches(IBaseValidation.NameRegex, defaultname);
        }


        [Theory]
        [InlineData("12433")]
        //[InlineData("12433asas")]
        public async Task Domain_Currency_Id_Validation_Test_Method(string defaultnumber)
        {
            //Arrange
            Provider provider = new Provider();
            _Utest.Setup(demo => demo.baseValidation.Idvalidate()).ReturnsAsync(await provider.Idvalidate());

            //Acting
            IUnitofTest baseValidation = _Utest.Object;
            var actualed_value = baseValidation.baseValidation.Idvalidate();

            //Asserting
            Assert.NotNull(actualed_value);
            Assert.Matches(IBaseValidation.IdRegex, defaultnumber);
        }

    }
}
