using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Api.Entity.Print;

namespace Tea.Api.Data.Repository.Print
{
    public interface IPrintRepository
    {
        Task<byte[]> StgBillPrint(BillPrintModel _input);

        Task<byte[]> SupplierBillPrint(BillPrintModel _input);
        Task<string> WhatsAppMessage(WhatsAppModel message);

    }
}
