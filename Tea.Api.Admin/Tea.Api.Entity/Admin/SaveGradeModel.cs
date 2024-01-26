using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Admin
{
    public class SaveGradeModel
    {
        public long? GradeId { get; set; }
        public string? GradeName { get; set; }
        public long? TenantId { get; set; }
        public long? CreatedBy { get; set; }
    }

    public class DeleteGradeModel
    {
        public long? GradeId { get; set; }
      
    }
}
