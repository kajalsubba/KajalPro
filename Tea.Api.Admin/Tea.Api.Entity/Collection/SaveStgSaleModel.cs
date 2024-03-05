using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Collection
{
    public class SaveStgSaleModel
    {
        public long? TotalFirstWeight { get; set; }
        public long? TotalWetLeaf { get; set; }
        public long? TotalLongLeaf { get; set; }
        public long? TotalDeduction { get; set; }
        public long? TotalFinalWeight { get; set; }

        public DateTime? SaleDate { get; set; }
        public long? AccountId { get; set; }
        public long? VehicleId { get; set; }
        public double? FieldCollectionWeight { get; set; }
        public int? FineLeaf { get; set; }
        public double? ChallanWeight { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Incentive { get; set; }
        public decimal? GrossAmount { get; set; }
        public string? Remarks { get; set; }
        public int? SaleTypeId { get; set; }
        public long? TenantId { get; set; }
        public long? CreatedBy { get; set; }

        public List<StgApproveData> ApproveList { get; set; }
    }

    public class StgApproveData
    {
        public Boolean? IsApprove { get; set; }
        public long? CollectionId { get; set; }
        public string? Status { get; set; }
    }

}
