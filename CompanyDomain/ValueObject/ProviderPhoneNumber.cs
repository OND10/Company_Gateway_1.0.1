using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyDomain.ValueObject
{
    public class ProviderPhoneNumber
    {
        public List<string> Value {  get; set; }

        public ProviderPhoneNumber(List<string> value)    
        {
            Value = value;
        }
    }
}
