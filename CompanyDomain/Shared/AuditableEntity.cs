using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayDomain.Common
{
    public class AuditableEntity
    {
        public DateTime CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedById { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public DateTime DeletedOn { get; set; }
        public bool IsActive { get; set; } = false;

    }
}
