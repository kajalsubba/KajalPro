using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Admin
{
    public class SaveVehicleModel
    {
        public string? VehicleNo { get; set; }  
        public string? VehicleDetails { get; set; }  
        public long? TenantId { get; set; }  
        public long? CreatedBy { get; set; } 
    }
}
