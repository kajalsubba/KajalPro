using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Accounts
{
    public class SaveSeasonAdvanceModel
    {
        public long? SeasonAdvanceId { get; set; }

        public DateTime? AdvancedDate { get; set; }
        
        public long? ClientId { get; set; }
        public decimal? Amount { get; set; }
        public long? TenantId { get; set; }
        public long? CreatedBy { get; set; }
    }

    public class GetSeasonAdvanceModel
    {
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public long? TenantId { get; set; }
    }
}
