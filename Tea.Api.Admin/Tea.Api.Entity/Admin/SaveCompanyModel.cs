using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Admin
{
    public class SaveCompanyModel
    {
        public long? CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyLogo { get; set; }

        public IFormFile? Image { get; set; }
        public string? UserEmail { get; set; }
        public string? ContactNo { get; set; }
        public string? CompanyDetails { get; set; }
        public long? TenantId { get; set; }
        public long? CreatedBy { get; set; }
      
    }

    public class GetCompanyModel
    {
        public long? TenantId { get; set; }
    }
}
