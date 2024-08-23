using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Admin
{
    public class ChangePasswordModel
    {
        public string? UserName { get; set; }

        public string? LoginType { get; set; }
        public string? Password { get; set; }
        public long? TenantId { get; set; }

        public long? CreatedBy { get; set; }
    }

    public class ChangeUserPasswordModel
    {
        public long? UserId { get; set; }

        public string? Password { get; set; }
        public long? TenantId { get; set; }

        public long? CreatedBy { get; set; }
    }
}
