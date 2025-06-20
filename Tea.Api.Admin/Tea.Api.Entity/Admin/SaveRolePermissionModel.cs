using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Admin
{
    public class SaveRolePermissionModel
    {
        public List<PermissionList>? PermissionLists { get; set; }
        public long? TenantId { get; set; }
        public long? CreatedBy { get; set; }
    }

    public class PermissionList
    {
        public long? UserRoleId { get; set; }
        public int? SubModuleId { get; set; }
        public bool? DeleteData { get; set; }
        public bool? EditData { get; set; }
        public bool? HideModule { get; set; }
        public bool? SaveData { get; set; }
        public bool? Upload { get; set; }
        public bool? ViewData { get; set; }
        public long? TenantId { get; set; }
    }
}
