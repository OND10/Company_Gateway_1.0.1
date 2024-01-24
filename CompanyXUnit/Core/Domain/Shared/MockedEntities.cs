using CompanyDomain.Entities;
namespace CompanyXUnit.Core.Domain.Shared
{
    public class MockedEntities
    {

        //Company
        public Companyy company = new Companyy
        {
            Id = 1,
            ArabicName = "ثروات",
            EnglishName = "Tharwat",
            Email = "tharwat@gmail.com",
            Address = "Almasbahi Round behind NiceWare"

        };

        //Currancy
        public Currency currency = new Currency
        {
            Id = 1,
            ArabicName = "ريال",
            EnglishName = "dollar",
            Type = ""

        };

        //Location
        public Location location = new Location
        {
            CountryId = 1,

            Description = "",
            Name = "Location"
        };


        public Provider provider = new Provider
        {


            phoneNumbers = new List<CompanyDomain.ValueObject.ProviderPhoneNumber>(),
            EnglishName = "",
            Email = "",
            Name = ""

        };


        public Product products = new Product
        {
            
            Name ="",
            Description ="",
            Amount =   33

        };


        public Service service = new Service
        {

            Name = "",
            Description = "",
          

        };
        public List<Companyy> companylist = new List<Companyy>()
        {
                new Companyy
                {
                    Id = 1,
                    ArabicName = "ثروات",
                    EnglishName = "Tharwat",
                    Email = "tharwat@gmail.com",
                    Address = "Almasbahi Round behind NiceWare"
                },

                new Companyy
                {
                    Id = 3,
                    ArabicName = "النجم",
                    EnglishName = "Alnajm",
                    Email = "najm@gmail.com",
                    Address = "AlDiari Round "
                },

        };


    }
}
