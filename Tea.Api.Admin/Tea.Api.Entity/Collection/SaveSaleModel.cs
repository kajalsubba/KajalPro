using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Collection
{
    public class SaveSaleModel
    {
        public long? SaleId { get; set; }
        public long? ApproveId { get; set; }
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
  
    }

    public class SelectSale
    {
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public string? VehicleNo { get; set; }
        public long? FactoryId { get; set; }
        public long? AccountId { get; set; }
        public int? SaleTypeId { get; set; }
        public long? TenantId { get; set; }
    }
}
