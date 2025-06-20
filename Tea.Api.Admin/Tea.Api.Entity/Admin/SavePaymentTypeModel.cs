using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Admin
{
    public class SavePaymentTypeModel
    {
        public long? PaymentTypeId { get; set; }
        public string? PaymentType { get; set; }
        public long? TenantId { get; set; }
        public long? CreatedBy { get; set; }
    }

    public class GetPaymentTypeModel
    {
        public long? TenantId { get; set; }
      
    }
}
