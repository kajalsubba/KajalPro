using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Collection
{
    public class MonthWiseWeightModel
    {
        public long? TenantId { get; set; }
        public string? Year { get; set; }
        public string? Category { get; set; }
    }
}
