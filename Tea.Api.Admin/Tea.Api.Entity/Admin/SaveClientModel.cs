using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Admin
{
    public class SaveClientModel
    {
        public long? ClientId { get; set; }
        public string? ClientFirstName { get; set; }
        public string? ClientMiddleName { get; set; }
        public string? ClientLastName { get; set; }
        public string? ClientAddress { get; set; }
        public string? ContactNo { get; set; }
        public string? EmailId { get; set; }
        public long? CategoryID { get; set; }
        public long? TenantId { get; set; }
        public bool? IsActive { get; set; }
        public long? CreatedBy { get; set; }
 
    }
}
