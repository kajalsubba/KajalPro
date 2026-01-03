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
        public int? GradeId { get; set; }
        public int? TripId { get; set; }
        public long? ClientId { get; set; }
        public long? CreatedBy { get; set; }
    }

    public class StgBagDataModel
    {
        public long? TenantId { get; set; }
        public long? CollectionId { get; set; }
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
        public long? CollectionId { get; set; }
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
        public List<StgRateFixModel>? RateData { get; set; }
        public long? TenantId { get; set; }
        public long? CreatedBy { get; set; }

    }
    public class LateralStgSaveModel
    {
        public long? SaleId { get; set; }
        public long? ApproveId { get; set; }

        public long? AccountId { get; set; }

        public DateTime? CollectionDate { get; set; }

        public string? VehicleNo { get; set; }
        public float? TotalFirstWeight { get; set; }
        public float? TotalWetLeaf { get; set; }
        public float? TotalLongLeaf { get; set; }
        public float? TotalDeduction { get; set; }
        public float? TotalFinalWeight { get; set; }
        public int? FineLeaf { get; set; }
        public float? ChallanWeight { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Incentive { get; set; }
        public decimal? GrossAmount { get; set; }
        public string? Remarks { get; set; }
        public List<LateralStgList>? lateralStgLists { get; set; }
        public long? TenantId { get; set; }
        public long? CreatedBy { get; set; }
    }

    public class LateralStgList
    {
        public long? ClientId { get; set; }
        public decimal? FirstWeight { get; set; }
        public decimal? WetLeaf { get; set; }
        public decimal? LongLeaf { get; set; }
        public decimal? Deduction { get; set; }
        public decimal? FinalWeight { get; set; }
        public decimal? Rate { get; set; }
        public int? GradeId { get; set; }
        public string? Remarks { get; set; }
        public int? TripId { get; set; }
        public int? TenantId { get; set; }
    }
    public class StgRateFixModel
    {
        public long? CollectionId { get; set; }
        public decimal? Rate { get; set; }
    }

    public class GetStgVehicleModel
    {
        public string? FromDate { get; set; }
        public long? TenantId { get; set; }

    }
    public class GetStgPendingDateModel
    {
        public long? TenantId { get; set; }

    }

    public class GetStgTransferModel
    {
        public string? VehicleNo { get; set; }
        public int? TripId { get; set; }
        public string? CollectionDate { get; set; }
        public long? TenantId { get; set; }
        public long? CreatedBy { get; set; }
    }

    public class GetStgHistoryModel
    {
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public long? TenantId { get; set; }
        public long? ClientId { get; set; }
        public long? CreatedBy { get; set; }
    }

    public class GetStgRateFixFilterModel
    {
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public long? TenantId { get; set; }
        public bool? IsModify { get; set; }
    }
    public class GetRecoveryVehicleModel
    {
        public string? CollectionDate { get; set; }
        public long? TenantId { get; set; }
    }


}
