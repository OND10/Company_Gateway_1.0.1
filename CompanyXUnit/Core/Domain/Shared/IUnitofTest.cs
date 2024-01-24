using CompanyDomain.Common;
using GatewayDomain.Common;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyXUnit.Core.Domain.Shared
{
    public interface IUnitofTest
    {

        IBaseValidation baseValidation { get; }
        IEmailValidation emailValidation { get; }
        IPhoneNumberValidation phoneValidation { get; }
        IStatusValidation statusValidation { get; }


    }
}
