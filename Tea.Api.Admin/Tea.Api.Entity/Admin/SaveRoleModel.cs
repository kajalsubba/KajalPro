using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Admin
{
    public class SaveRoleModel
    {
        public long? UserRoleId { get; set; }
        public string? RoleName { get; set; }
        public string? RoleDescription { get; set; }
        public long? TenantId { get; set; }
        public long? CreatedBy { get; set; }
    }

    public class GetRoleModel
    {
        public long? TenantId { get; set; }
    }
}
