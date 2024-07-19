using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Api.Data.Repository.Print;
using Tea.Api.Data.UnitOfWork;
using Tea.Api.Entity.Print;

namespace Tea.Api.Service.Print
{
    public class PrintService : IPrintService
    {
        readonly IUnitOfWork _unitOfWork;
        public PrintService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        async Task<byte[]> IPrintService.StgBillPrint(BillPrintModel _input)
        {
            byte[] ds = await _unitOfWork.PrintRepository.StgBillPrint(_input);
            return ds;
        }

       async Task<byte[]> IPrintService.SupplierBillPrint(BillPrintModel _input)
        {
            byte[] ds = await _unitOfWork.PrintRepository.SupplierBillPrint(_input);
            return ds;
        }

       async Task<string> IPrintService.WhatsAppMessage(WhatsAppModel message)
        {
            return await _unitOfWork.PrintRepository.WhatsAppMessage(message);

        }
    }
}
