using GatewayDomain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyDomain.Entities
{
    public class Currency:AuditableEntity, IBaseValidation
    {
     
        public int Id { get; set; }
        public string ArabicName { get; set; } = string.Empty;
        public string EnglishName { get; set; } = string.Empty;
        public string Type {  get; set; } = string.Empty;

        public async Task<string> Idvalidate()
        {
            if (Id == null)
            {
                return await Task<string>.FromResult("Please Enter an Id");
            }

            return await Task.FromResult<string>("");
        }

        public async Task<string> Namevalidate()
        {
            if (string.IsNullOrEmpty(ArabicName))
            {
                return await Task.FromResult<string>("Please Enter a correct Name to be considered");
            }
            if (ArabicName.Trim().Any())
            {
                return await Task.FromResult<string>("Please Enter a correct Name to be considered");
            }
            if (string.IsNullOrEmpty(EnglishName))
            {
                return await Task.FromResult<string>("Please Enter a correct Name to be considered");
            }
            if (EnglishName.Trim().Any())
            {
                return await Task.FromResult<string>("Please Enter a correct Name to be considered");
            }
            return await Task.FromResult<string>("");
        }
    }
}
