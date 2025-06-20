using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Admin
{
    public class RolePermission
    {
        public long? TenantId { get; set; }
        public long? RoleId { get; set; }
    }
}
