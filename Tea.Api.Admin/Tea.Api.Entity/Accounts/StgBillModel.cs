using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Accounts
{
    public class StgBillModel
    {
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public long? ClientId { get; set; }
        public long? TenantId { get; set; }
    }

    public class SaveStgBill
    {
        public DateTime? BillDate { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public long? ClientId { get; set; }
        public decimal? FinalWeight { get; set; }
        public decimal? TotalStgAmount { get; set; }
        public decimal? TotalStgPayment { get; set; }
        public decimal? PreviousBalance { get; set; }
        public decimal? StandingSeasonAdv { get; set; }
        public decimal? Incentive { get; set; }
        public decimal? Transporting { get; set; }
        public decimal? GreenLeafCess { get; set; }
        public decimal? FinalBillAmount { get; set; }
        public decimal? LessSeasonAdv { get; set; }
        public decimal? AmountToPay { get; set; }
        public decimal? PaidAmount { get; set; }
        public decimal? OutstandingAmount { get; set; }
        public long? TenantId { get; set; }
        public long? CreatedBy { get; set; }

        public List<StgCollectionData>? CollectionData { get; set; }
        public List<StgPaymentData>? PaymentData { get; set; }
    }

    public class StgCollectionData
    {
        public long CollectionId { get; set; }
    }
    public class StgPaymentData
    {
        public long PaymentId { get; set; }
    }

    public class GetSTGBillHistoryModel
    {
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public long? ClientId { get; set; }
        public long? TenantId { get; set; }
    }
}
