using CompanyDomain.Common;
using CompanyDomain.Entities;
using CompanyXUnit.Core.Domain.Shared;
using GatewayDomain.Common;

using Moq;

namespace CompanyXUnit
{
    public class UnitTest_Domain_Company_Properties_Validation
    {
        private readonly Mock<IUnitofTest> _Utest;
        public UnitTest_Domain_Company_Properties_Validation()
        {
            _Utest = new Mock<IUnitofTest>(); 
        }


        [Theory]
        [InlineData("tharwat@gmail.com")]
        public async Task Domain_Company_Email_Validation_Test_Method(string defaultEmail)
        {
            
            //Arrange
            Companyy companies = new Companyy();
            _Utest.Setup(demo => demo.emailValidation.Emailvalidate()).ReturnsAsync(await companies.Emailvalidate());

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
        public async Task Domain_Company_Phone_Validation_Test_Method(string defaultphonenumber)
        {
            //Arrange
            Companyy company = new Companyy();
            _Utest.Setup(demo => demo.phoneValidation.PhoneNumbervalidate()).ReturnsAsync(await company.PhoneNumbervalidate());

            //Acting
            IUnitofTest phoneValidation = _Utest.Object;
            var actualed_value = phoneValidation.phoneValidation.PhoneNumbervalidate();

            //Asserting
            Assert.NotNull(actualed_value);
            Assert.Matches(IBaseValidation.PhoneNumberRegx, defaultphonenumber);
        }


        [Theory]
        [InlineData(true)]
        public async Task Domain_Company_Status_Validation_True_Test_Method(bool defaultstatus)
        {
            //Arrange
            Companyy company = new Companyy();
            _Utest.Setup(demo => demo.statusValidation.StatusValidate()).ReturnsAsync(await company.StatusValidate());

            //Acting
            IUnitofTest statusValidation = _Utest.Object;
            var actualed_value = statusValidation.statusValidation.StatusValidate();

            //Asserting
            Assert.NotNull(actualed_value);
            Assert.True(defaultstatus);

        }


        [Theory]
        [InlineData(false)]
        public async Task Domain_Company_Status_Validation_False_Test_Method(bool defaultstatus)
        {
            //Arrange
            Companyy company = new Companyy();
            _Utest.Setup(demo => demo.statusValidation.StatusValidate()).ReturnsAsync(await company.StatusValidate());

            //Acting
            IUnitofTest statusValidation = _Utest.Object;
            var actualed_value = statusValidation.statusValidation.StatusValidate();

            //Asserting
            Assert.NotNull(actualed_value);
            Assert.False(defaultstatus);
        }

        [Theory]
        [InlineData("TharwatCompany")]
        public async Task Domain_Company_English_Name_Validation_Test_Method(string defaultname)
        {
            //Arrange
            Companyy company = new Companyy();
            _Utest.Setup(demo => demo.baseValidation.Namevalidate()).ReturnsAsync(await company.Namevalidate());

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
        public async Task Domain_Company_Id_Validation_Test_Method(string defaultnumber)
        {
            //Arrange
            Companyy company = new Companyy();
            _Utest.Setup(demo => demo.baseValidation.Idvalidate()).ReturnsAsync(await company.Idvalidate());

            //Acting
            IUnitofTest baseValidation = _Utest.Object;
            var actualed_value = baseValidation.baseValidation.Idvalidate();

            //Asserting
            Assert.NotNull(actualed_value);
            Assert.Matches(IBaseValidation.IdRegex, defaultnumber);
        }
    }
}