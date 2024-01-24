using CompanyDomain.Entities;
using CompanyDomain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayDomain.Interfaces
{
    public interface ICompanyRepository:IGenericRepository<Companyy>
    {
      
     //   Task<Result<IEnumerable<Company>>> Query(string query);

    }
}
