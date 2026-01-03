using iText.Kernel.Pdf;
using Microsoft.AspNetCore.Mvc;
using Tea.Api.Entity.Collection;
using Tea.Api.Entity.Print;
using Tea.Api.Service.Print;


namespace Tea.Api.Print.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrintController : ControllerBase
    {
        readonly IPrintService _printService;
        private readonly string _PdfPath;
        private readonly string _relativePath;
        public PrintController(IPrintService printService, IConfiguration config)
        {
            _printService = printService;
            _PdfPath = config["ConnectionStrings:PdfPath"];
            _relativePath = config["ConnectionStrings:RelativePath"];
        }

        [HttpPost, Route("StgBillPrint")]
        public async Task<IActionResult> StgBillPrint([FromBody] BillPrintModel _input)
        {
            byte[] pdfBytes = await _printService.StgBillPrint(_input);
            return File(pdfBytes, "application/pdf", "BillNo" + _input.BillNo + ".pdf");
        }

        [HttpPost, Route("SupplierBillPrint")]
        public async Task<IActionResult> SupplierBillPrint([FromBody] BillPrintModel _input)
        {
            byte[] pdfBytes = await _printService.SupplierBillPrint(_input);
            return File(pdfBytes, "application/pdf", "BillNo" + _input.BillNo + ".pdf");
        }


        [HttpPost, Route("SupplierBillSaveToPdf")]
        public async Task<IActionResult> SupplierBillSaveToPdf([FromBody] BillPrintModel _input)
        {
            // 1. Generate non-encrypted PDF
            byte[] pdfBytes = await _printService.SupplierBillSaveToPdf(_input);

            // string fileName = $"BillNo_{_input.BillNo}.pdf";
            string fileName = $"{Guid.NewGuid()}.pdf";

            string _supplierPdfPath = Path.Combine(_PdfPath, "Supplier");

            string _supplierRelativePath = Path.Combine(_relativePath, "Supplier");
            // 2. Ensure directory exists
            if (!Directory.Exists(_supplierPdfPath))
                Directory.CreateDirectory(_supplierPdfPath);

            string filePath = Path.Combine(_supplierPdfPath, fileName);

            // 3. Apply password encryption
            // string password = _input.ClientName+_input.Number; // fallback password

            string namePart = (_input.ClientName ?? string.Empty).PadRight(4).Substring(0, 4).ToUpper();
            string numberPart = (_input.Number ?? string.Empty);
            numberPart = numberPart.Length >= 4 ? numberPart.Substring(numberPart.Length - 4) : numberPart.PadLeft(4, '0');
            string password = namePart + numberPart;

            byte[] encryptedPdf = EncryptPdf(pdfBytes, password);

            // 4. Save encrypted file
            await System.IO.File.WriteAllBytesAsync(filePath, encryptedPdf);

            // 5. Create public URL
            string fileUrl = $"https://glsportals.com/{_supplierRelativePath.Replace("\\", "/")}/{fileName}";

            return Ok(new { url = fileUrl, fileName = fileName });
        }



        [HttpPost, Route("StgBillSaveToPdf")]
        public async Task<IActionResult> StgBillSaveToPdf([FromBody] BillPrintModel _input)
        {
            // 1. Generate non-encrypted PDF
            byte[] pdfBytes = await _printService.StgBillSaveToPdf(_input);

            // string fileName = $"BillNo_{_input.BillNo}.pdf";
            string fileName = $"{Guid.NewGuid()}.pdf";

            string _stgPdfPath = Path.Combine(_PdfPath, "Stg");

            string _stgRelativePath = Path.Combine(_relativePath, "Stg");
            // 2. Ensure directory exists
            if (!Directory.Exists(_stgPdfPath))
                Directory.CreateDirectory(_stgPdfPath);

            string filePath = Path.Combine(_stgPdfPath, fileName);

            // 3. Apply password encryption
            // string password = _input.ClientName+_input.Number; // fallback password


            string password = _input.Number ?? "";

            byte[] encryptedPdf = EncryptPdf(pdfBytes, password);

            // 4. Save encrypted file
            await System.IO.File.WriteAllBytesAsync(filePath, encryptedPdf);

            // 5. Create public URL
            string fileUrl = $"https://glsportals.com/{_stgRelativePath.Replace("\\", "/")}/{fileName}";

            return Ok(new { url = fileUrl, fileName = fileName });
        }


        private byte[] EncryptPdf(byte[] pdfBytes, string password)
        {
            using var input = new MemoryStream(pdfBytes);
            using var output = new MemoryStream();

            var writerProps = new WriterProperties()
                .SetStandardEncryption(
                    System.Text.Encoding.UTF8.GetBytes(password),  // user password
                    System.Text.Encoding.UTF8.GetBytes(password),  // owner password
                    EncryptionConstants.ALLOW_PRINTING,
                    EncryptionConstants.ENCRYPTION_AES_256
                );

            using var writer = new PdfWriter(output, writerProps);
            using var reader = new PdfReader(input);
            using var pdfDoc = new PdfDocument(reader, writer);

            pdfDoc.Close();
            return output.ToArray();
        }

        [HttpPost, Route("SalePrint")]
        public async Task<IActionResult> SalePrint([FromBody] PrintSaleModel _input)
        {
            byte[] pdfBytes = await _printService.SalePrint(_input);
            return File(pdfBytes, "application/pdf", "SaleStatement" + _input.TenantId + ".pdf");
        }

    }
}
