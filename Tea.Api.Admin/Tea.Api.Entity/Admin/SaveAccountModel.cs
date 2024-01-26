using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Admin
{
    public class SaveAccountModel
    {
        public long? AccountId { get; set; }
        public string? AccountName { get; set; }
        public long? FactoryId { get; set; }
        public long? TenantId { get; set; }
        public bool? IsActive { get; set; }
        public long? CreatedBy { get; set; }
    }

    public class DeleteAccountModel
    {
        public long? AccountId { get; set; }
    }
    }
