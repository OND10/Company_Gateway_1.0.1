using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyDomain.Exception
{
    public class Result<T>
    {
        public bool IsSuccess { get; private set; }
        public bool IsFailure { get; private set; }
        public string ErrorMessage {  get; private set; }

        protected Result(bool iSuccess, string errorMessage)
        {
            IsSuccess = iSuccess;
            ErrorMessage = errorMessage;
        }

        public static Task<Result<T>> Success()
        {
            return  Task.FromResult<Result<T>>(new Result<T>(true, string.Empty));
        }  

        public static Task<Result<T>>Success(string message)
        {
            return Task.FromResult<Result<T>>(new Result<T>(true, message));
        }
        public static Task<Result<T>> Failure(string message)
        {
            return Task.FromResult<Result<T>>(new Result<T>(true, message));
        }

    }
}
