using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Admin
{
    public class SaveFactoryModel
    {
        public long? FactoryId { get; set; }
        public string? FactoryName { get; set; }
        public string? FactoryAddress { get; set; }
        public string? ContactNo { get; set; }
        public string? EmailId { get; set; }
        public long? TenantId { get; set; }
        public bool? IsActive { get; set; }
        public long? CreatedBy { get; set; }
    }
}
