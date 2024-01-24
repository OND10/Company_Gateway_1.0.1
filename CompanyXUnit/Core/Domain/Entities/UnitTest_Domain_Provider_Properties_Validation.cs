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
    public class UnitTest_Domain_Provider_Properties_Validation
    {

        private readonly Mock<IUnitofTest> _Utest;

        public UnitTest_Domain_Provider_Properties_Validation()
        {
            _Utest = new Mock<IUnitofTest>();
        }


        [Theory]
        [InlineData("provider10@gmail.com")]
        //[InlineData("assgmail.com")]
        public async Task Domain_Provider_Email_Validation_Test_Method(string defaultEmail)
        {

            //Arrange
            Provider provider = new Provider();
            _Utest.Setup(demo => demo.emailValidation.Emailvalidate()).ReturnsAsync(await provider.Emailvalidate());

            //Acting
            IUnitofTest emailValidation = _Utest.Object;
            var actualed_value = emailValidation.emailValidation.Emailvalidate();

            //Asserting
            Assert.NotNull(actualed_value);
            //Assert.Matches(IBaseValidation.EmailRegx, companies.Emailvalidate().Result);
            Assert.Matches(IBaseValidation.EmailRegx, defaultEmail);
        }



        [Theory]
        [InlineData("+967779136337")]
        [InlineData("+967775046313")]
        //[InlineData("+9677sdfdfgg")]
        public async Task Domain_Provider_Phone_Validation_Test_Method(string defaultphonenumber)
        {
            //Arrange
            Provider provider = new Provider();
            _Utest.Setup(demo => demo.phoneValidation.PhoneNumbervalidate()).ReturnsAsync(await provider.PhoneNumbervalidate());

            //Acting
            IUnitofTest phoneValidation = _Utest.Object;
            var actualed_value = phoneValidation.phoneValidation.PhoneNumbervalidate();

            //Asserting
            Assert.NotNull(actualed_value);
            Assert.Matches(IBaseValidation.PhoneNumberRegx, defaultphonenumber);
        }


        [Theory]
        [InlineData("TharwatCompany")]
        public async Task Domain_Provider_English_Name_Validation_Test_Method(string defaultname)
        {
            //Arrange
            Provider provider = new Provider();
            _Utest.Setup(demo => demo.baseValidation.Namevalidate()).ReturnsAsync(await provider.Namevalidate());

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
        public async Task Domain_Provider_Id_Validation_Test_Method(string defaultnumber)
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
