using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Collection
{
    public class SaveSupplierModel
    {
        public long? CollectionId { get; set; }
        public DateTime? CollectionDate { get; set; }
        public string? VehicleNo { get; set; }
        public long? ClientId { get; set; }
        public long? AccountId { get; set; }
        public double? FineLeaf { get; set; }
        public double? ChallanWeight { get; set; }
        public decimal? Rate { get; set; }
        public decimal? GrossAmount { get; set; }
        public int? TripId { get; set; }
        public string? Status { get; set; }
        public string? Remarks { get; set; }
        public long? TenantId { get; set; }
        public long? CreatedBy { get; set; }

       // public IFormFile? ChallanImage { get; set; }
    }

    public class SaveChallanImageModel
    {
        public long? TenantId { get; set; }
        public long? CollectionId { get; set; }
         public IFormFile? ChallanImage { get; set; }
    }

    public class SupplierFilterModel
    {
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public long? TenantId { get; set; }
        public string? VehicleNo { get; set; }
        public string? Status { get; set; }

        public int? TripId { get; set; }

        public long? CreatedBy { get; set; }
    }

    public class SaveApproveSupplier
    {
        public long? CollectionId { get; set; }
        public string? SaleStatus { get; set; }
        public DateTime? CollectionDate { get; set; }

        public long? AccountId { get; set; }
        public long? VehicleId { get; set; }
        //public float? FieldCollectionWeight { get; set; }
        public int? FineLeaf { get; set; }
        public float? ChallanWeight { get; set; }
        public int? SaleTypeId { get; set; }
  
        public long? TenantId { get; set; }
        public long? CreatedBy { get; set; }
    }

    public class GetSupplierRateFixModel
    {
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public long? FactoryId { get; set; }
        public long? AccountId { get; set; }
        public long? ClientId { get; set; }
 
        public long? TenantId { get; set; }

    }

    public class GetSupplierVehicleModel
    {
        public string? FromDate { get; set; }
         public long? TenantId { get; set; }

    }

    public class SaveSupplierRateFixModel
    {
        public List<SupplierRateFixModel> RateData { get; set; }
        public long? TenantId { get; set; }
        public long? CreatedBy { get; set; }

    }

    public class SupplierRateFixModel
    {
        public long? CollectionId { get; set; }
        public decimal? Rate { get; set; }
    }


}
