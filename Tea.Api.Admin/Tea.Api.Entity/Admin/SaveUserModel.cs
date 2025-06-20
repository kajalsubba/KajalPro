using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Admin
{
    public class SaveUserModel
    {
        public long? UserId { get; set; }
        public string? LoginUserName { get; set; }
        public string? UserFirstName { get; set; }
        public string? UserMiddleName { get; set; }
        public string? UserLastName { get; set; }
        public string? UserEmail { get; set; }
        public string? ContactNo { get; set; }
        public string? Password { get; set; }
        public long? UserRoleId { get; set; }
        public long? TenantId { get; set; }
        public bool? IsActive { get; set; }
        public long? CreatedBy { get; set; }
       
    }

    public class SelectUserModel
    {
        public long? TenantId { get; set; }
    }
}
