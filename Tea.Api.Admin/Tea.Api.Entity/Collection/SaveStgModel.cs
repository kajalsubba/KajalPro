using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Collection
{
    public class SaveStgModel
    {

        public long? CollectionId { get; set; }
        public DateTime? CollectionDate { get; set; }
        public int? TripId { get; set; }
        public string? VehicleNo { get; set; }
        public long? ClientId { get; set; }
        public decimal? FirstWeight { get; set; }
        public int? WetLeaf { get; set; }
        public int? LongLeaf { get; set; }
        public int? Deduction { get; set; }
        public decimal? FinalWeight { get; set; }
        public decimal? Rate { get; set; }

        public decimal? GrossAmount { get; set; }
        public int? GradeId { get; set; }
        public string? Remarks { get; set; }
        public long? TenantId { get; set; }
        public string? Status { get; set; }
        public long? CreatedBy { get; set; }
   
    }

    public class StgFilterModel
    {
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public long? TenantId { get; set; }
        public string? VehicleNo { get; set; }
        public string? Status { get; set; }
        public int? TripId { get; set; }

        public long? CreatedBy { get; set; }
    }

    public class SaveApproveStg
    {
        public long? TotalFirstWeight { get; set; }
        public long? TotalWetLeaf { get; set; }
        public long? TotalLongLeaf { get; set; }
        public long? TotalDeduction { get; set; }
        public long? TotalFinalWeight { get; set; }
        
        public long? TenantId { get; set; }
        public long? CreatedBy { get; set; }

        public List<ApproveStgMapping>? ApproveList { get; set; }
    }

    public class ApproveStgMapping
    {
        public Boolean? IsApprove { get; set; }
        public  long ? CollectionId { get; set;}
        public string? Status { get; set; }
    }

    public class GetStgRateFixModel
    {
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public long? TenantId { get; set; }
        public long? ClientId { get; set; }
        public int? GradeId { get; set; }

    }

    public class SaveStgRateFixModel
    {
        public List<StgRateFixModel> RateData { get; set; }
        public long? TenantId { get; set; }
        public long? CreatedBy { get; set; }

    }

    public class StgRateFixModel
    {
        public long? CollectionId { get; set; }
        public decimal? Rate { get; set; }
    }

}
