using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Api.Entity.Print;

namespace Tea.Api.Service.Print
{
    public interface IPrintService
    {
        Task<byte[]> StgBillPrint(BillPrintModel _input);
        Task<byte[]> SupplierBillPrint(BillPrintModel _input);
    }
}
