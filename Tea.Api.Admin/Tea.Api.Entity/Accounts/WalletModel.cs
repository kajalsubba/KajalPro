using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Accounts
{
    public class WalletModel
    {
        public long? WalletId { get; set; }
        public long? UserId { get; set; }
        public decimal? Amount { get; set; } // Use decimal for currency
        public string? Narration { get; set; }
        public long? TenantId { get; set; }
        public long? CreatedBy { get; set; }
    }

    public class WalletHistModel
    {
        public long? TenantId { get; set; }
        public string? FromDate { get; set; } // Nullable
        public string? ToDate { get; set; }   // Nullable
        public long? UserId { get; set; }
        public long? CreatedBy { get; set; }
    }

    public class WalletBalanceModel
    {
        public long? TenantId { get; set; }
        public long? UserId { get; set; }
    }
}
