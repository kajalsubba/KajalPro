using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Accounts
{
    public class SaleSummaryModel
    {
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public long? FactoryId { get; set; }
        public long? AccountId { get; set; }
        public long? TenantId { get; set; }
    }
}
