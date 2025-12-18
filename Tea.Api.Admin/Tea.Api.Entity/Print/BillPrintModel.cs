using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Print
{
    public class BillPrintModel
    {
        public long? TenantId { get; set; }
        public long? BillNo { get; set; }
        public string? ClientName { get; set; }
        public string? Number { get; set; }
    }

   
}
