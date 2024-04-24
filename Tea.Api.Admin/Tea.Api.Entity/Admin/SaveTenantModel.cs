using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Admin
{
    public class SaveTenantModel
    {
        public long? TenantId { get; set; }
        public string? TenantName { get; set; }
        public string? TenantOwner { get; set; }
        public string? TenantEmail { get; set; }
        public string? TenantContactNo { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }

        public bool? IsActive { get; set; }
    }

    public class SelectTenantModel
    {

    }
}
