using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Admin
{
    public class FinancialYearModel
    {
        public long? FinancialYearId { get; set; }
        public long? FinancialYear { get; set; }
        public long? TenantId { get; set; }
        public long? CreatedBy { get; set; }
    }
}
