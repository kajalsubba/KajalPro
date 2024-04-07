using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Accounts
{
    public class SupplierSummaryModel
    {
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public long? ClientId { get; set; }
        public long? TenantId { get; set; }
    }

    public class SmartHistoryModel
    {
        public long? TenantId { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public string? CategoryName { get; set; }
        public long? ClientId { get; set; }
    }
}
