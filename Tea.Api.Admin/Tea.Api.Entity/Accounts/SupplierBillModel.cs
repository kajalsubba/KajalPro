using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Accounts
{
    public class SupplierBillModel
    {
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public long? ClientId { get; set; }
        public long? TenantId { get; set; }
    }
    public class SaveSupplierBill
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
        public decimal? Commision { get; set; }
        public decimal? GreenLeafCess { get; set; }
        public decimal? FinalBillAmount { get; set; }
        public decimal? LessSeasonAdv { get; set; }
        public decimal? AmountToPay { get; set; }
        public long? TenantId { get; set; }
        public long? CreatedBy { get; set; }

        public List<SupplierCollectionData>? CollectionData { get; set; }
        public List<SupplierPaymentData>? PaymentData { get; set; }
    }

    public class SupplierCollectionData
    {
        public long CollectionId { get; set; }
    }
    public class SupplierPaymentData
    {
        public long PaymentId { get; set; }
    }
    public class GetSupplierBillHistoryModel
    {
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public long? ClientId { get; set; }
        public long? TenantId { get; set; }
    }
}
