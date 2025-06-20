using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.MessageBroker
{
    public class SupplierMessageModel
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

        public IFormFile? ChallanImage { get; set; }
    }

    public class SupplierMQModel
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

        public IFormFile? ChallanImage { get; set; }
        public byte[]? ChallanImageByte { get; set; }
    }

    public class SignalRNotify
    {
        public bool? Message { get; set; }
        public long? TenantId { get; set; }

    }

}
