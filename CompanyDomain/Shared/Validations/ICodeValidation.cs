using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyDomain.Shared.Validations
{
    public interface ICodeValidation
    {
        Task<string> Codevalidate();
    }
}
