using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Accounts
{
    public class SaveRecoveryModel
    {
        public DateTime? RecoveryDate { get; set; }
        public long? ClientId { get; set; }
        public string? ClientCategory { get; set; } = string.Empty;

        public long? CategoryId { get; set; }

        public string? RecoveryType { get; set; }
        public decimal? Amount { get; set; }
        public string? Narration { get; set; } = string.Empty;
        public long? TenantId { get; set; }
        public long? CreatedBy { get; set; }
    }

    public class RecoveryFilterRequest
    {
        public long? TenantId { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public long? CategoryId { get; set; }
        public long? ClientId { get; set; }
        public string? RecovertType { get; set; }
        public long? CreatedBy { get; set; }
    }
}
