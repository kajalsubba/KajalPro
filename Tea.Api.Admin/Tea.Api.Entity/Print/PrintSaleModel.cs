using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Print
{
    public class PrintSaleModel
    {
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public string? VehicleNo { get; set; }
        public long? FactoryId { get; set; }
        public long? AccountId { get; set; }
        public string? FineLeaf { get; set; }
        public int? SaleTypeId { get; set; }
        public long? TenantId { get; set; }
    }
}
