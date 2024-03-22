﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Accounts
{
    public class SavePaymentModel
    {
        public long? PaymentId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string? ClientCategory { get; set; }
        public long? ClientId { get; set; }
        public long? PaymentTypeId { get; set; }
        public decimal? Amount { get; set; }
        public string? Narration { get; set; }
        public long? TenantId { get; set; }
        public long? CreatedBy { get; set; }
    }

    public class GetPaymentModel
    {
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public string? ClientCategory { get; set; }
        public long? ClientId { get; set; }
        public long? TenantId { get; set; }
    }
}
