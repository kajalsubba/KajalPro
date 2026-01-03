using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Admin
{
    public class TargetCollectionModel
    {
    }
    public class TargetModel
    {
        public long? TargetId { get; set; }
        public long? ClientId { get; set; }
        public int ?FinancialYearId { get; set; }
        public long? TargetWeight { get; set; }
        public long? TenantId { get; set; }
        public long? CreatedBy { get; set; }
    }
}
