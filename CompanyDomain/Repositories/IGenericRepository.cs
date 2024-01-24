using CompanyDomain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GatewayDomain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<Result<IEnumerable<T>>> GetAllAsync();
        Task<Result<T>> AddAsync(T model);
        Task<Result<T>> UpdateAsync(T model);
        Task<Result<T>> DeleteAsync(T model);
        Task<Result<T>> GetByIdAsync(int id);
        Task<Result<T>> GetByCodeAsync(string code);
        Task<Result<IEnumerable<T>>> Query(string query);

    }
}
