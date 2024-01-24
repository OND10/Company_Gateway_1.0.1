using GatewayDomain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyDomain.Entities
{
    public class Location: IBaseValidation
    {
        public int id;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        
        public int CountryId;
   //     public ICollection<Country>? countries { get; set; }

        public async Task<string> Idvalidate()
        {
            if (id == null)
            {
                return await Task<string>.FromResult("Please Enter an Id");
            }
            return await Task.FromResult<string>("");
        }

        public async Task<string> Namevalidate()
        {
            if (string.IsNullOrEmpty(Name))
            {
                return await Task.FromResult<string>("Please Enter a correct Name to be considered");
            }
            if (Name.Trim().Any())
            {
                return await Task.FromResult<string>("Please Enter a correct Name to be considered");
            }
            return await Task.FromResult<string>("");
        }
    }
}
