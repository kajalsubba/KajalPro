using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Admin
{
    public class CommonSelectModel
    {
        public long? TenantId { get; set; }
        public bool? IsClientView { get; set; }
    }

    public class SelectCategoryClientModel
    {
        public long? TenantId { get; set; }
        public string? Category { get; set; }
    }

    public class SelectFinancialYear
    {
        public long? TenantId { get; set; }

    }
}
