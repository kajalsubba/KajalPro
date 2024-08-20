using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Collection
{
    public class VehicleLockModel
    {
        public string? VehicleNo { get; set; }
        public int? TripId { get; set; }
        public DateTime? LockDate { get; set; }
        public long? TenantId { get; set; }
        public long? CreatedBy { get; set; }
    }

    public class GetVehicleLockModel
    {
        public string? VehicleNo { get; set; }
        public int? TripId { get; set; }
        public string? LockDate { get; set; }
        public long? TenantId { get; set; }
        public long? CreatedBy { get; set; }
    }
}
