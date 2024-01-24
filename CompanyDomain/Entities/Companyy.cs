using CompanyDomain.Common;
using GatewayDomain.Common;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CompanyDomain.Entities
{
    public class Companyy:AuditableEntity,IBaseValidation,IEmailValidation,IPhoneNumberValidation,IStatusValidation
    {
      
        public int Id { get; set; }
        public string EnglishName { get; set; } = "";
        public string ArabicName { get; set; } = "";
        public string Description { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        private string Phonenumber { get; set; } = string.Empty;

        public string PhoneNumber
        {
            get
            {
                return Phonenumber;
            }
            set
            {
                if (!string.IsNullOrEmpty(Phonenumber))
                {
                    value = Phonenumber;
                }
            }
        }
        public string Email { get; set; } = string.Empty;
        public string? Address { get; set; }
        public bool Status { get; set; }
        public ICollection<Provider>? providers { get; set; }
        public int LocationId {  get; set; }
        public ICollection<Service>? services { get; set; }
        public ICollection<Currency>? currencies { get; set; }
        public ICollection<Product>? products { get; set; }

        public async Task<string> Emailvalidate()
        {
            string validEmail = IBaseValidation.EmailRegx;
            if (string.IsNullOrWhiteSpace(Email))
            {
                return await Task.FromResult<string>("Please Enter a correct CompanyEmail to be considered");
                //return await Task.FromResult<string>("osama@gmail.com");
            }

            if (!Regex.IsMatch(Email, validEmail))
            {
                return await Task.FromResult<string>("Please Enter a correct CompanyEmail to be considered");

                //return await Task.FromResult<string>("osama@gmail.com");
            }

            return await Task.FromResult<string>("");
        }

        public async Task<string> Idvalidate()
        {
            if(Id == null)
            {
                return await Task<string>.FromResult("Please Enter an Id");
            }

            return await Task.FromResult<string>("");
        }

        public async Task<string> Namevalidate()
        {
            if (string.IsNullOrEmpty(EnglishName))
            {
                return await Task.FromResult<string>("Please Enter a correct EnglishName to be considered");
            }
            if (string.IsNullOrEmpty(ArabicName))
            {
                return await Task.FromResult<string>("Please Enter a correct ArabicName to be considered");
            }
            if (ArabicName.Trim().Any())
            {
                return await Task.FromResult<string>("Please Enter a correct ArabicName to be considered");
            }
            if (EnglishName.Trim().Any())
            {
                return await Task.FromResult<string>("Please Enter a correct EnglishName to be considered");
            }

            return await Task.FromResult<string>("");
        }

        public async Task<string> PhoneNumbervalidate()
        {
            string validPhone = IBaseValidation.PhoneNumberRegx;
            if (string.IsNullOrWhiteSpace(PhoneNumber))
            {
                return await Task.FromResult<string>("Please Enter a correct CompanyPhone to be considered");
            }

            if (!Regex.IsMatch(PhoneNumber, validPhone))
            {
                return await Task.FromResult<string>("Please Enter a correct CompanyPhone to be considered");
            }

            return await Task.FromResult<string>("");
        }

        public async Task<bool> StatusValidate()
        {
            if(Status is true)
            {
                return await Task.FromResult<bool>(true);
            }
            if (Status is false)
            {
                return await Task.FromResult<bool>(false);
            }
            return false;
        }

        //Implementation Validation

        //public async Task<string> isValid()
        //{

        //    string validEmail =  IBaseValidation.EmailRegx = @"^\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Z|a-z]{2,}\\b";
        //    string validPhone = IBaseValidation.PhoneNumberRegx = @"^(77|78|73|71)\d{9}$";
        //    if (string.IsNullOrEmpty(ArabicName))
        //    {
        //        return await Task.FromResult<string>("CompanyArabicName field is Required");
        //    }

        //    if (string.IsNullOrWhiteSpace(ArabicName))
        //    {
        //        return await Task.FromResult<string>("Please Enter a correct CompanyArabicName to be considered");
        //    }

        //    if (string.IsNullOrWhiteSpace(EnglishName))
        //    {
        //        return await Task.FromResult<string>("Please Enter a correct CompanyEnglishName to be considered");
        //    }

        //    if (string.IsNullOrWhiteSpace(Email))
        //    {
        //        return await Task.FromResult<string>("Please Enter a correct CompanyEmail to be considered");
        //    }

        //    if (!Regex.IsMatch(Email, validEmail))
        //    {
        //        return await Task.FromResult<string>("Please Enter a correct CompanyEmail to be considered");
        //    }

        //    if (string.IsNullOrWhiteSpace(PhoneNumber))
        //    {
        //        return await Task.FromResult<string>("Please Enter a correct CompanyPhone to be considered");
        //    }

        //    if (!Regex.IsMatch(PhoneNumber, validPhone))
        //    {
        //        return await Task.FromResult<string>("Please Enter a correct CompanyPhone to be considered");
        //    }

        //    return await Task.FromResult<string>("");
        //}

    }

}
