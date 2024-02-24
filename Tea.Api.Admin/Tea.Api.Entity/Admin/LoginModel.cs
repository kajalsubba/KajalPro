using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Admin
{
    public class LoginModel
    {
        public string? UserName { get; set; }
        public string? Password { get; set; } 
    }

    public class ClientLoginModel
    {
        public string? UserId { get; set; }
        public string? Password { get; set; }
        public long? TenantId { get; set; }
    }
}
