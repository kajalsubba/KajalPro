using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Admin
{
    public class SaveCategoryModel
    {
        public long? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public long? TenantId { get; set; }
        public long? CreatedBy { get; set; }
    
    }
}
