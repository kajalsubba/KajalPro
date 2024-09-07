
using PdfSharpCore;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System.Data;
using System.Globalization;
using System.Reflection.Metadata;
using System.Xml.Linq;
using Tea.Api.Data.Common;
using Tea.Api.Data.DbHandler;
using Tea.Api.Data.WhatsApp;
using Tea.Api.Entity.Print;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using Twilio.Base;

namespace Tea.Api.Data.Repository.Print
{
    public class PrintRepository : IPrintRepository
    {
        readonly WhatsAppService _whatsAppService;


        readonly IDataHandler _dataHandler;

        public PrintRepository(IDataHandler dataHandler)
        {
            _dataHandler = dataHandler;
            _whatsAppService = new WhatsAppService();

        }

        async Task<byte[]> IPrintRepository.SalePrint(PrintSaleModel _input)
        {
            DataSet ds;
            List<ClsParamPair> clsPairs = new()
            {

                new ClsParamPair("@FromDate", _input.FromDate??""),
                new ClsParamPair("@ToDate", _input.ToDate??""),
                new ClsParamPair("@VehicleNo", _input.VehicleNo??""),
                new ClsParamPair("@FactoryId", _input.FactoryId??0),
                new ClsParamPair("@AccountId", _input.AccountId??0),
                new ClsParamPair("@SaleTypeId", _input.SaleTypeId??0),
                new ClsParamPair("@FineLeaf", _input.FineLeaf??""),
                new ClsParamPair("@TenantId", _input.TenantId ??0)

            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Sales].[GetSalesData]", clsPairs);

            DateTime fromDate =Convert.ToDateTime(_input.FromDate);
            DateTime toDate = Convert.ToDateTime(_input.ToDate);
            string? factoryName = string.Empty;
            string? address = string.Empty;
            string? supplierName = string.Empty;


            foreach (DataRow row in ds.Tables[0].Rows)
            {
                factoryName = Convert.ToString(row["FactoryName"]);
                address = Convert.ToString(row["FactoryAddress"]);
                supplierName = Convert.ToString(row["AccountName"]);
              
            }
            var data = new PdfDocument();

            string htmlContent = "<div style = 'text-align: center; margin-bottom: 8px;'>";
            htmlContent += "<h3> Green Leaves Sale Statement </h3>";
            htmlContent += "</div>";
            htmlContent += "<div style = 'margin-top: 5px auto; heigth:1000px; max-width: 600px; padding: 20px; border: 0px solid #ccc; background-color: #FFFFFF; font-family: Arial, sans-serif; font-size: 12px;' >";

            htmlContent += "<div style = 'margin-top: 10px auto; heigth:120px; max-width: 100px; padding: 17px; border: 1px solid #ccc; background-color: #FFFFFF; font-family: Arial, sans-serif;' >";
            htmlContent += "<table style = 'width: 100%; border-collapse: collapse;'>";

            htmlContent += "<tbody>";
            htmlContent += "<tr>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > For the Period From :</td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;font-weight: bold;' > " + fromDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) + "</td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > To :</td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;font-weight: bold;'  > " + toDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) + "</td>";
            htmlContent += "</tr>";
            htmlContent += "<tr>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > Factory:</td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;font-weight: bold;' > " + factoryName + "</td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > Address :</td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;font-weight: bold;'  > " + address + "</td>";
            htmlContent += "</tr>";
            htmlContent += "<tr>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > Supplier Name :</td>";
            htmlContent += "<td style = 'margin: 0; text-align: left; font-weight: bold;' >" + supplierName + " </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left; font-weight: bold;'  ></td>";
            htmlContent += "</tr>";

            htmlContent += "</tbody>";
            htmlContent += "</table>";
            htmlContent += "</div>";
       
            htmlContent += "<table style = 'width: 100%; border-collapse: collapse;'>";
            htmlContent += "<thead>";
            htmlContent += "<tr>";
            htmlContent += "<th style = 'padding: 4px; text-align: left; border-bottom: 1px solid #ddd;' > Date </th>";
            htmlContent += "<th style = 'padding: 4px; text-align: left; border-bottom: 1px solid #ddd;' > Vehicle No </th>";
            htmlContent += "<th style = 'padding: 4px; text-align: center; border-bottom: 1px solid #ddd;' > Fine(%) </th>";
            htmlContent += "<th style = 'padding: 4px; text-align: center; border-bottom: 1px solid #ddd;' > Challan Wgt. </th>";
            htmlContent += "<th style = 'padding: 4px; text-align: right; border-bottom: 1px solid #ddd;' > Rate</th>";
            htmlContent += "<th style = 'padding: 4px; text-align: right; border-bottom: 1px solid #ddd;' > Amount </th>";
            htmlContent += "<th style = 'padding: 4px; text-align: right; border-bottom: 1px solid #ddd;' > Inc.Amount </th>";
            htmlContent += "<th style = 'padding: 4px; text-align: right; border-bottom: 1px solid #ddd;' > Final Amount </th>";

            htmlContent += "</tr><hr/>";
            htmlContent += "</thead>";
            htmlContent += "<tbody>";
          
            int VehicleCount = 0;
            int FineAvg = 0;
            decimal TotalFine = 0;
            decimal TotalChallan = 0;
            decimal AvgRate = 0;
            decimal TotalAmount = 0;
            decimal TotalIncAmount = 0;
            decimal TotalFinalAmount = 0;

            DateTime utcNow = DateTime.UtcNow;
            TimeZoneInfo istZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime istTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, istZone);
            string ReportTime = istTime.ToString("dd-MM-yyyy HH:mm:ss");

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    htmlContent += "<tr>";
                    htmlContent += "<td style = 'padding: 4px;margin:1px; text-align: left; ' >" + Convert.ToString(row["SaleDate"]) + " </td>";
                    htmlContent += "<td style = 'padding: 4px;margin:1px; text-align: left; ' > " + Convert.ToString(row["VehicleNo"]) + " </td>";
                    htmlContent += "<td style = 'padding: 4px;margin:1px; text-align: center; ' > " + Convert.ToString(row["FineLeaf"]) + " </td>";
                    htmlContent += "<td style = 'padding: 4px;margin:1px; text-align: center; ' > " + Convert.ToString(row["ChallanWeight"]) + "</td>";
                    htmlContent += "<td style = 'padding: 4px;margin:1px; text-align: right; ' > " + Convert.ToString(row["Rate"]) + " </td>";
                    htmlContent += "<td style = 'padding: 4px;margin:1px; text-align: right; ' > " + Convert.ToString(row["GrossAmount"]) + " </td>";
                    htmlContent += "<td style = 'padding: 4px;margin:1px; text-align: right; ' > " + Convert.ToString(row["IncentiveAmount"]) + "</td>";
                    htmlContent += "<td style = 'padding: 4px;margin:1px; text-align: right; ' > " + Convert.ToString(row["FinalAmount"]) + "</td>";

                    htmlContent += "</tr>";

                    VehicleCount++;
                    TotalFine += decimal.TryParse(Convert.ToString(row["FineLeaf"]), out decimal FineLeaf) ? FineLeaf : 0;
                    TotalChallan += decimal.TryParse(Convert.ToString(row["ChallanWeight"]), out decimal ChallanKg) ? ChallanKg : 0;
                    TotalIncAmount += decimal.TryParse(Convert.ToString(row["IncentiveAmount"]), out decimal IncAmt) ? IncAmt : 0;
                    TotalAmount += decimal.TryParse(Convert.ToString(row["GrossAmount"]), out decimal Amount) ? Amount : 0;
                    TotalFinalAmount += decimal.TryParse(Convert.ToString(row["FinalAmount"]), out decimal FinalAmtKg) ? FinalAmtKg : 0;
                    AvgRate = Math.Round((TotalFinalAmount / TotalChallan), 2);
                    FineAvg = Convert.ToInt32(Math.Round((TotalFine / VehicleCount), 0));
                };
                htmlContent += "</tbody>";
                htmlContent += "<tfoot>";
                htmlContent += "<tr>";
                htmlContent += "<td style = 'padding: 8px; text-align: left;  border-top: 1px solid #ddd;font-weight: bold;'> Total</td>";
                htmlContent += "<td style = 'padding: 8px; text-align: center; border-top: 1px solid #ddd;font-weight: bold;' >" + VehicleCount + " </td>";
                htmlContent += "<td style = 'padding: 8px; text-align: center; border-top: 1px solid #ddd;font-weight: bold;' >" + FineAvg + " </td>";
                htmlContent += "<td style = 'padding: 8px; text-align: center; border-top: 1px solid #ddd;font-weight: bold;' >" + TotalChallan + " </td>";
                htmlContent += "<td style = 'padding: 8px; text-align: right; border-top: 1px solid #ddd;font-weight: bold;' >" + AvgRate + " </td>";
                htmlContent += "<td style = 'padding: 8px; text-align: right; border-top: 1px solid #ddd;font-weight: bold;' >" + TotalAmount + " </td>";
                htmlContent += "<td style = 'padding: 8px; text-align: right; border-top: 1px solid #ddd;font-weight: bold;' >" + TotalIncAmount + " </td>";
                htmlContent += "<td style = 'padding: 8px; text-align: right; border-top: 1px solid #ddd;font-weight: bold;' >" + TotalFinalAmount + " </td>";

                htmlContent += "</tr>";
                htmlContent += "</tfoot>";
            }
            htmlContent += "</table>";
           

            htmlContent += "<br>";

            htmlContent += "<table style = 'width: 100%; border-collapse: collapse;'>";
            htmlContent += "<tbody>";
            htmlContent += "<tr>";
            htmlContent += "<td  style = 'margin: 0; text-align: left;font-size:12px;'  >Final Amount In word -" + NumberToWordConvertor.ConvertToWords(Convert.ToInt64(TotalFinalAmount)) + " Only </td>";
            htmlContent += "</tr>";

            htmlContent += "</tbody>";
            htmlContent += "</table>";
   
            htmlContent += "</div>";
            htmlContent += "<footer>";
            //htmlContent += "<p> Declaration: In the green leaf provided by me/us, I/we confirm that only PPFs (Plant Protection Formulations) recommended in the Plant Protection Code have been used. No chemicals or pesticides banned in India have been employed. Should it be found that any banned pesticides or chemicals, or their residues, exceed the prescribed limits, the Tea Board is authorized to take appropriate action against me/us.<br>";
            htmlContent += "<table style = 'width: 100%; border-collapse: collapse;'>";
            htmlContent += "<tbody>";

            htmlContent += "<tr>";
            htmlContent += "<td style = 'margin: 5; text-align: left;font-weight: bold;font-size:10px;' >Check & Verified </td>";
            htmlContent += "<td style = 'margin: 5; text-align: right; font-weight: bold;font-size:10px;'  >Signature</td>";
            htmlContent += "</tr>";

            htmlContent += "</tbody>";
            htmlContent += "</table>";
            htmlContent += "</footer>";

            PdfGenerator.AddPdfPages(data, htmlContent, PageSize.A4);

            //PdfPage page = data.AddPage();

            //page.Size = PageSize.A4;
            //double pageHeight = page.Height - 40; // Leaving margin
            
            int currentPage = 0;
            XFont pageNumberFont = new XFont("Arial", 6, XFontStyle.Regular);
            int PageHi = 802;
            int pagewith = 595;
            foreach (PdfPage pages in data.Pages)
            {
                ++currentPage;
                using (var gfx = XGraphics.FromPdfPage(pages))
                {
                    gfx.DrawString($"Page {currentPage} of {data.PageCount}", pageNumberFont, XBrushes.Black, new XRect(20, PageHi + 10, pagewith - 40, 20), XStringFormats.CenterRight);
                    gfx.DrawString($"Report Generate on : {ReportTime}", pageNumberFont, XBrushes.Black, new XRect(20, PageHi + 10, pagewith - 40, 20), XStringFormats.CenterLeft);

                }
            }


            byte[]? response = null;
            using (MemoryStream ms = new MemoryStream())
            {
                data.Save(ms);
                response = ms.ToArray();
            }

            return response;
        }

        async Task<byte[]> IPrintRepository.StgBillPrint(BillPrintModel _input)
        {

            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {

                new ClsParamPair("@BillId", _input.BillNo == null ? 0 : _input.BillNo),
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId)

            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Bill].[GenerateSTGBill]", oclsPairs);
            string? CompanyName = string.Empty;
            string? Address = string.Empty;
            string? ContactNo = string.Empty;
            string? Email = string.Empty;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                CompanyName = Convert.ToString(row["CompanyName"]);
                Address = Convert.ToString(row["CompanyDetails"]);
                ContactNo = Convert.ToString(row["ContactNo"]);
                Email = Convert.ToString(row["UserEmail"]);
            }

            DataRow firstRow = ds.Tables[1].Rows[0];


            string? BillId = Convert.ToString(firstRow["BillId"]);
            string? BillDate = Convert.ToString(firstRow["BillDate"]);
            string? FromDate = Convert.ToString(firstRow["FromDate"]);
            string? ToDate = Convert.ToString(firstRow["ToDate"]);
            string? ClientName = Convert.ToString(firstRow["ClientName"]);
            string? ClientId = Convert.ToString(firstRow["ClientId"]);
            string? ClientAddress = Convert.ToString(firstRow["ClientAddress"]);
            string? ClientContactNo = Convert.ToString(firstRow["ContactNo"]);

            string? StandingSeasonAdv = Convert.ToString(firstRow["StandingSeasonAdv"]);
            string? Incentive = Convert.ToString(firstRow["IncentiveAmount"]);
            string? Transport = Convert.ToString(firstRow["TransportingAmount"]);
            string? Cess = Convert.ToString(firstRow["CessAmount"]);
            string? PrevousAmount = Convert.ToString(firstRow["PreviousBalance"]);
            string? LessSeasonAdv = Convert.ToString(firstRow["LessSeasonAmount"]);
            string? AmountToPay = Convert.ToString(firstRow["AmountToPay"]);
            string? RecieptAmount = Convert.ToString(firstRow["PaidAmount"]);
            string? Deposite_PayableAmount = Convert.ToString(firstRow["OutstandingAmount"]);
            string? Deposite_PayableLabel = Convert.ToDecimal(firstRow["OutstandingAmount"]) > 0 ? "Diposite" : "Paybale";

            string? RoundAmountToPay = Convert.ToString(firstRow["RoundAmountToPay"]);

            var data = new PdfDocument();

            string htmlContent = "<div style = 'margin: 30px auto; heigth:1000px; max-width: 600px; padding: 20px; border: 1px solid #ccc; background-color: #FFFFFF; font-family: Arial, sans-serif; font-size: 12px;' >";
            //htmlContent += "<div style = 'margin-bottom: 20px; text-align: center;'>";
            //htmlContent += "<img src = 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcROnYPD5QO8ZJvPQt8ClnJNPXduCeX89dSOxA&usqp=CAU' alt = 'School Logo' style = 'max-width: 100px; margin-bottom: 10px;' >";
            //htmlContent += "</div>";
            htmlContent += "<div style = 'text-align: center; margin-bottom: 8px;'>";
            htmlContent += "<h3> Green Leaf Supplied Statement </h3>";
            htmlContent += "</div>";
            htmlContent += "<p style = 'margin: 0;' >" + CompanyName + "</p>";
            htmlContent += "<p style = 'margin: 0;' > " + Address + "</p>";
            htmlContent += "<p style = 'margin: 0;' > " + ContactNo + " </p>";
            htmlContent += "<p style = 'margin: 0;' > " + Email + " </p>";
            htmlContent += "<div style = 'margin: 20px auto; heigth:120px; max-width: 100px; padding: 20px; border: 1px solid #ccc; background-color: #FFFFFF; font-family: Arial, sans-serif;' >";
            htmlContent += "<table style = 'width: 100%; border-collapse: collapse;'>";

            htmlContent += "<tbody>";
            htmlContent += "<tr>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > Bill No :</td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;font-weight: bold;' > " + BillId + "</td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > Bill Date :</td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;font-weight: bold;'  > " + BillDate + "</td>";
            htmlContent += "</tr>";
            htmlContent += "<tr>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > For the Period from :</td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;font-weight: bold;' > " + FromDate + "</td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > To :</td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;font-weight: bold;'  > " + ToDate + "</td>";
            htmlContent += "</tr>";
            htmlContent += "<tr>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > Client Name :</td>";
            htmlContent += "<td style = 'margin: 0; text-align: left; font-weight: bold;' >" + ClientName + " </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > Client Id :</td>";
            htmlContent += "<td style = 'margin: 0; text-align: left; font-weight: bold;'  >" + ClientId + "</td>";
            htmlContent += "</tr>";
            htmlContent += "<tr>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > Adddress :</td>";
            htmlContent += "<td style = 'margin: 0; text-align: left; font-weight: bold;' > " + ClientAddress + " </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > Contact No: </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left; font-weight: bold;'  >" + ClientContactNo + "</td>";
            htmlContent += "</tr>";
            htmlContent += "</tbody>";
            htmlContent += "</table>";
            htmlContent += "</div>";
            htmlContent += "<div style = 'text-align: center; margin-bottom: 8px;'>";
            htmlContent += "<h6> Leaf Collection Data </h6>";
            htmlContent += "</div>";
            htmlContent += "<table style = 'width: 100%; border-collapse: collapse;'>";
            htmlContent += "<thead>";
            htmlContent += "<tr>";
            htmlContent += "<th style = 'padding: 4px; text-align: left; border-bottom: 1px solid #ddd;' > Date </th>";
            htmlContent += "<th style = 'padding: 4px; text-align: left; border-bottom: 1px solid #ddd;' > Grade </th>";
            htmlContent += "<th style = 'padding: 4px; text-align: left; border-bottom: 1px solid #ddd;' > Collection </th>";
            htmlContent += "<th style = 'padding: 4px; text-align: left; border-bottom: 1px solid #ddd;' > Rejected </th>";
            htmlContent += "<th style = 'padding: 4px; text-align: left; border-bottom: 1px solid #ddd;' > Final (KG) </th>";
            htmlContent += "<th style = 'padding: 4px; text-align: left; border-bottom: 1px solid #ddd;' > Rate </th>";
            htmlContent += "<th style = 'padding: 4px; text-align: right; border-bottom: 1px solid #ddd;' > Amount </th>";
            htmlContent += "</tr><hr/>";
            htmlContent += "</thead>";
            htmlContent += "<tbody>";
            decimal TotalCollection = 0;
            decimal TotalReject = 0;
            decimal TotalFinal = 0;
            decimal AvgRate = 0;
            decimal TotalAmount = 0;
            HashSet<string> distinctDates = new HashSet<string>();

            if (ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    htmlContent += "<tr>";
                    htmlContent += "<td style = 'padding: 4px;margin:1px; text-align: left; ' >" + Convert.ToString(row["CollectionDate"]) + " </td>";
                    htmlContent += "<td style = 'padding: 4px;margin:1px; text-align: left; ' > " + Convert.ToString(row["GradeName"]) + " </td>";
                    htmlContent += "<td style = 'padding: 4px;margin:1px; text-align: left; ' > " + Convert.ToString(row["FirstWeight"]) + " </td>";
                    htmlContent += "<td style = 'padding: 4px;margin:1px; text-align: left; ' > " + Convert.ToString(row["Deduction"]) + "</td>";
                    htmlContent += "<td style = 'padding: 4px;margin:1px; text-align: left; ' > " + Convert.ToString(row["FinalWeight"]) + " </td>";
                    htmlContent += "<td style = 'padding: 4px;margin:1px; text-align: left; ' > " + Convert.ToString(row["Rate"]) + " </td>";
                    htmlContent += "<td style = 'padding: 4px;margin:1px; text-align: right; ' > " + Convert.ToString(row["Amount"]) + "</td>";
                    htmlContent += "</tr>";

                    distinctDates.Add(Convert.ToString(row["CollectionDate"]) ?? "");

                    TotalCollection += decimal.TryParse(Convert.ToString(row["FirstWeight"]), out decimal CollectionKg) ? CollectionKg : 0;
                    TotalReject += decimal.TryParse(Convert.ToString(row["Deduction"]), out decimal RejectKg) ? RejectKg : 0;
                    TotalFinal += decimal.TryParse(Convert.ToString(row["FinalWeight"]), out decimal FinalKg) ? FinalKg : 0;

                    TotalAmount += decimal.TryParse(Convert.ToString(row["Amount"]), out decimal Amount) ? Amount : 0;
                    AvgRate = Math.Round((TotalAmount / TotalFinal), 2);
                };
                htmlContent += "</tbody>";
                htmlContent += "<tfoot>";
                htmlContent += "<tr>";
                htmlContent += "<td style = 'padding: 8px; text-align: left;  border-top: 1px solid #ddd;font-weight: bold;'> Total Days: " + distinctDates.Count + "</td>";
                htmlContent += "<td style = 'padding: 8px; text-align: left; border-top: 1px solid #ddd;font-weight: bold;' > </td>";
                htmlContent += "<td style = 'padding: 8px; text-align: left; border-top: 1px solid #ddd;font-weight: bold;' >" + TotalCollection + " </td>";
                htmlContent += "<td style = 'padding: 8px; text-align: left; border-top: 1px solid #ddd;font-weight: bold;' >" + TotalReject + " </td>";
                htmlContent += "<td style = 'padding: 8px; text-align: left; border-top: 1px solid #ddd;font-weight: bold;' >" + TotalFinal + " </td>";
                htmlContent += "<td style = 'padding: 8px; text-align: left; border-top: 1px solid #ddd;font-weight: bold;' >" + AvgRate + " </td>";
                htmlContent += "<td style = 'padding: 8px; text-align: right; border-top: 1px solid #ddd;font-weight: bold;' >" + TotalAmount + " </td>";
                htmlContent += "</tr>";
                htmlContent += "</tfoot>";
            }
            htmlContent += "</table>";

            htmlContent += "<div style = 'text-align: center; margin-bottom: 8px;'>";
            htmlContent += "<h6> Payment Data </h6>";
            htmlContent += "</div>";

            htmlContent += "<table style = 'width: 100%; border-collapse: collapse;'>";
            htmlContent += "<thead>";
            htmlContent += "<tr>";
            htmlContent += "<th style = 'padding: 4px; text-align: left; border-bottom: 1px solid #ddd;' > Pay Date </th>";
            htmlContent += "<th style = 'padding: 4px; text-align: left; border-bottom: 1px solid #ddd;' > Naration </th>";
            htmlContent += "<th style = 'padding: 4px; text-align: right; border-bottom: 1px solid #ddd;' > Amount </th>";

            htmlContent += "</tr><hr/>";
            htmlContent += "</thead>";
            htmlContent += "<tbody>";

            decimal TotalPayAmount = 0;

            if (ds.Tables[2].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[2].Rows)
                {
                    htmlContent += "<tr>";
                    htmlContent += "<td style = 'padding: 4px;margin:1px; text-align: left; ' >" + Convert.ToString(row["CollectionDate"]) + " </td>";
                    htmlContent += "<td style = 'padding: 4px;margin:1px; text-align: left; ' > " + Convert.ToString(row["Narration"]) + " </td>";
                    htmlContent += "<td style = 'padding: 4px;margin:1px; text-align: right; ' > " + Convert.ToString(row["Amount"]) + " </td>";

                    htmlContent += "</tr>";

                    TotalPayAmount += decimal.TryParse(Convert.ToString(row["Amount"]), out decimal totalPay) ? totalPay : 0;

                };
                htmlContent += "</tbody>";
                htmlContent += "<tfoot>";
                htmlContent += "<tr>";
                htmlContent += "<td style = 'padding: 8px; text-align: left; border-top: 1px solid #ddd; font-weight: bold;'> Total </td>";
                htmlContent += "<td style = 'padding: 8px; text-align: left; border-top: 1px solid #ddd;' > </td>";
                htmlContent += "<td style = 'padding: 8px; text-align: right; border-top: 1px solid #ddd; font-weight: bold;' >" + TotalPayAmount + " </td>";

                htmlContent += "</tr>";
                htmlContent += "</tfoot>";
            }
            htmlContent += "</table>";

            htmlContent += "<div style = 'margin: 20px auto; heigth:120px; max-width: 100px; padding: 20px; border: 1px solid #ccc; background-color: #FFFFFF; font-family: Arial, sans-serif;' >";
            htmlContent += "<table style = 'width: 100%; border-collapse: collapse;'>";

            htmlContent += "<tbody>";

            htmlContent += "<tr>";
            htmlContent += "<td style = 'margin: 0; text-align: left;font-weight: bold;' > Standing Season Advance :</td>";
            htmlContent += "<td style = 'margin: 0; text-align: right; font-weight: bold;' > " + StandingSeasonAdv + " </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' >Amount To be Paid:  </td>";
            htmlContent += "<td style = 'margin: 0; text-align: right; font-weight: bold;'  >" + AmountToPay + "</td>";
            htmlContent += "</tr>";
            htmlContent += "<tr>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > Incetive :</td>";
            htmlContent += "<td style = 'margin: 0; text-align: right;font-weight: bold;' > " + Incentive + "</td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > Amount Reciept:</td>";
            htmlContent += "<td style = 'margin: 0; text-align: right;font-weight: bold;'  >" + RecieptAmount + " </td>";
            htmlContent += "</tr>";
            htmlContent += "<tr>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > Previous Balance :</td>";
            htmlContent += "<td style = 'margin: 0; text-align: right;font-weight: bold;' > " + PrevousAmount + "</td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' >" + Deposite_PayableLabel + ":</td>";
            htmlContent += "<td style = 'margin: 0; text-align: right;font-weight: bold;'  >" + Deposite_PayableAmount + " </td>";
            htmlContent += "</tr>";
            htmlContent += "<tr>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > Transporting:</td>";
            htmlContent += "<td style = 'margin: 0; text-align: right; font-weight: bold;' >" + Transport + " </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' ></td>";
            htmlContent += "<td style = 'margin: 0; text-align: left; font-weight: bold;'  ></td>";
            htmlContent += "</tr>";
            htmlContent += "<tr>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' >Less GI Cess :</td>";
            htmlContent += "<td style = 'margin: 0; text-align: right; font-weight: bold;' > " + Cess + " </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > </td>";
            htmlContent += "<td style = 'margin: 0; text-align: right; font-weight: bold;'  ></td>";
            htmlContent += "</tr>";
            htmlContent += "<tr>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > Less Season Adv. :</td>";
            htmlContent += "<td style = 'margin: 0; text-align: right; font-weight: bold;' > " + LessSeasonAdv + " </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > </td>";
            htmlContent += "<td style = 'margin: 0; text-align: right; font-weight: bold;'  ></td>";
            htmlContent += "</tr>";
            htmlContent += "<tr>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left; ' >  </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > </td>";
            htmlContent += "<td style = 'margin: 0; text-align: right; font-weight: bold;'  ></td>";
            htmlContent += "</tr>";
            htmlContent += "< tr style = 'height: 20px;' ></ tr >";
            htmlContent += "<tr>";

            htmlContent += "<td colspan='4' style = 'margin: 0; text-align: left; font-weight: bold;'  >Reciept Amount In word " + NumberToWordConvertor.ConvertToWords(Convert.ToInt64(RoundAmountToPay)) + " Only </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left; ' >  </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' >  </td>";
            htmlContent += "<td style = 'margin: 0; text-align: right; font-weight: bold;'  ></td>";
            htmlContent += "</tr>";


            htmlContent += "</tbody>";
            htmlContent += "</table>";

            htmlContent += "</div>";


            htmlContent += "<br>";

            htmlContent += "<table style = 'width: 100%; border-collapse: collapse;'>";
            htmlContent += "<tbody>";
            htmlContent += "<tr>";
            htmlContent += "<td style = 'margin: 0; text-align: left;font-weight: bold;' >Check & Verified </td>";
            htmlContent += "<td style = 'margin: 0; text-align: right; font-weight: bold;'  >Recived Signature</td>";
            htmlContent += "</tr>";

            htmlContent += "</tbody>";
            htmlContent += "</table>";

            htmlContent += "</div>";
            htmlContent += "<h7> Report Genearate on :" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "</h7>";

            PdfGenerator.AddPdfPages(data, htmlContent, PageSize.A4);



            byte[]? response = null;
            using (MemoryStream ms = new MemoryStream())
            {
                data.Save(ms);
                response = ms.ToArray();
            }

            return response;
        }

        async Task<byte[]> IPrintRepository.SupplierBillPrint(BillPrintModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {

                new ClsParamPair("@BillId", _input.BillNo == null ? 0 : _input.BillNo),
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId)

            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Bill].[GenerateSuppleirBill]", oclsPairs);
            string? CompanyName = string.Empty;
            string? Address = string.Empty;
            string? ContactNo = string.Empty;
            string? Email = string.Empty;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                CompanyName = Convert.ToString(row["CompanyName"]);
                Address = Convert.ToString(row["CompanyDetails"]);
                ContactNo = Convert.ToString(row["ContactNo"]);
                Email = Convert.ToString(row["UserEmail"]);
            }

            DataRow firstRow = ds.Tables[1].Rows[0];


            string? BillId = Convert.ToString(firstRow["BillId"]);
            string? BillDate = Convert.ToString(firstRow["BillDate"]);
            string? FromDate = Convert.ToString(firstRow["FromDate"]);
            string? ToDate = Convert.ToString(firstRow["ToDate"]);
            string? ClientName = Convert.ToString(firstRow["ClientName"]);
            string? ClientId = Convert.ToString(firstRow["ClientId"]);
            string? ClientAddress = Convert.ToString(firstRow["ClientAddress"]);
            string? ClientContactNo = Convert.ToString(firstRow["ContactNo"]);

            string? StandingSeasonAdv = Convert.ToString(firstRow["StandingSeasonAdv"]);
            string? CommisonAmount = Convert.ToString(firstRow["CommisonAmount"]);
            //string? Transport = Convert.ToString(firstRow["TransportingAmount"]);
            string? Cess = Convert.ToString(firstRow["CessAmount"]);
            string? PrevousAmount = Convert.ToString(firstRow["PreviousBalance"]);
            string? LessSeasonAdv = Convert.ToString(firstRow["LessSeasonAmount"]);
            string? AmountToPay = Convert.ToString(firstRow["AmountToPay"]);
            string? RoundAmountToPay = Convert.ToString(firstRow["RoundAmountToPay"]);

            var data = new PdfDocument();

            string htmlContent = "<div style = 'margin: 30px auto; heigth:1000px; max-width: 600px; padding: 20px; border: 1px solid #ccc; background-color: #FFFFFF; font-family: Arial, sans-serif; font-size: 12px;' >";
            //htmlContent += "<div style = 'margin-bottom: 20px; text-align: center;'>";
            //htmlContent += "<img src = 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcROnYPD5QO8ZJvPQt8ClnJNPXduCeX89dSOxA&usqp=CAU' alt = 'School Logo' style = 'max-width: 100px; margin-bottom: 10px;' >";
            //htmlContent += "</div>";
            htmlContent += "<div style = 'text-align: center; margin-bottom: 8px;'>";
            htmlContent += "<h3> Green Leaf Supplied Statement </h3>";
            htmlContent += "</div>";
            htmlContent += "<p style = 'margin: 0;' >" + CompanyName + "</p>";
            htmlContent += "<p style = 'margin: 0;' > " + Address + "</p>";
            htmlContent += "<p style = 'margin: 0;' > " + ContactNo + " </p>";
            htmlContent += "<p style = 'margin: 0;' > " + Email + " </p>";
            htmlContent += "<div style = 'margin: 20px auto; heigth:120px; max-width: 100px; padding: 20px; border: 1px solid #ccc; background-color: #FFFFFF; font-family: Arial, sans-serif;' >";
            htmlContent += "<table style = 'width: 100%; border-collapse: collapse;'>";

            htmlContent += "<tbody>";
            htmlContent += "<tr>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > Bill No :</td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;font-weight: bold;' > " + BillId + "</td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > Bill Date :</td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;font-weight: bold;'  > " + BillDate + "</td>";
            htmlContent += "</tr>";
            htmlContent += "<tr>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > For the Period from :</td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;font-weight: bold;' > " + FromDate + "</td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > To :</td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;font-weight: bold;'  > " + ToDate + "</td>";
            htmlContent += "</tr>";
            htmlContent += "<tr>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > Client Name :</td>";
            htmlContent += "<td style = 'margin: 0; text-align: left; font-weight: bold;' >" + ClientName + " </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > Client Id :</td>";
            htmlContent += "<td style = 'margin: 0; text-align: left; font-weight: bold;'  >" + ClientId + "</td>";
            htmlContent += "</tr>";
            htmlContent += "<tr>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > Adddress :</td>";
            htmlContent += "<td style = 'margin: 0; text-align: left; font-weight: bold;' > " + ClientAddress + " </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > Contact No: </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left; font-weight: bold;'  >" + ClientContactNo + "</td>";
            htmlContent += "</tr>";
            htmlContent += "</tbody>";
            htmlContent += "</table>";
            htmlContent += "</div>";
            htmlContent += "<div style = 'text-align: center; margin-bottom: 8px;'>";
            htmlContent += "<h6> Leaf Collection Data </h6>";
            htmlContent += "</div>";
            htmlContent += "<table style = 'width: 100%; border-collapse: collapse;'>";
            htmlContent += "<thead>";
            htmlContent += "<tr>";
            htmlContent += "<th style = 'padding: 4px; text-align: left; border-bottom: 1px solid #ddd;' > Date </th>";
            htmlContent += "<th style = 'padding: 4px; text-align: left; border-bottom: 1px solid #ddd;' > VehicleNo </th>";
            htmlContent += "<th style = 'padding: 4px; text-align: left; border-bottom: 1px solid #ddd;' > Factory </th>";
            htmlContent += "<th style = 'padding: 4px; text-align: left; border-bottom: 1px solid #ddd;' > Account</th>";
            htmlContent += "<th style = 'padding: 4px; text-align: center; border-bottom: 1px solid #ddd;' > Fine Leaf(%) </th>";
            htmlContent += "<th style = 'padding: 4px; text-align: center; border-bottom: 1px solid #ddd;' > Challan Wgt. </th>";
            htmlContent += "<th style = 'padding: 4px; text-align: left; border-bottom: 1px solid #ddd;' > Rate </th>";
            htmlContent += "<th style = 'padding: 4px; text-align: right; border-bottom: 1px solid #ddd;' > Amount </th>";
            htmlContent += "</tr><hr/>";
            htmlContent += "</thead>";
            htmlContent += "<tbody>";
            decimal TotalChallanWeight = 0;
            decimal TotalFineLeaf = 0;
            int AvgFineLeaf = 0;
            decimal AvgRate = 0;
            decimal TotalAmount = 0;
            HashSet<string> distinctDates = new HashSet<string>();

            if (ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    htmlContent += "<tr>";
                    htmlContent += "<td style = 'padding: 4px;margin:1px; text-align: left; ' >" + Convert.ToString(row["CollectionDate"]) + " </td>";
                    htmlContent += "<td style = 'padding: 4px;margin:1px; text-align: left; ' > " + Convert.ToString(row["VehicleNo"]) + " </td>";
                    htmlContent += "<td style = 'padding: 4px;margin:1px; text-align: left; ' > " + Convert.ToString(row["FactoryName"]) + " </td>";
                    htmlContent += "<td style = 'padding: 4px;margin:1px; text-align: left; ' > " + Convert.ToString(row["AccountName"]) + "</td>";
                    htmlContent += "<td style = 'padding: 4px;margin:1px; text-align: center; ' > " + Convert.ToString(row["FineLeaf"]) + " </td>";
                    htmlContent += "<td style = 'padding: 4px;margin:1px; text-align: center; ' > " + Convert.ToString(row["ChallanWeight"]) + " </td>";
                    htmlContent += "<td style = 'padding: 4px;margin:1px; text-align: left; ' > " + Convert.ToString(row["Rate"]) + " </td>";
                    htmlContent += "<td style = 'padding: 4px;margin:1px; text-align: right; ' > " + Convert.ToString(row["Amount"]) + "</td>";
                    htmlContent += "</tr>";

                    distinctDates.Add(Convert.ToString(row["CollectionDate"]) ?? "");

                    TotalChallanWeight += decimal.TryParse(Convert.ToString(row["ChallanWeight"]), out decimal CollectionKg) ? CollectionKg : 0;
                    TotalFineLeaf += decimal.TryParse(Convert.ToString(row["FineLeaf"]), out decimal FineLeaf) ? FineLeaf : 0;
                    //TotalFinal += decimal.TryParse(Convert.ToString(row["FinalWeight"]), out decimal FinalKg) ? FinalKg : 0;

                    TotalAmount += decimal.TryParse(Convert.ToString(row["Amount"]), out decimal Amount) ? Amount : 0;
                    AvgRate = Math.Round((TotalAmount / TotalChallanWeight), 2);
                    AvgFineLeaf = Convert.ToInt16(Math.Round((TotalFineLeaf / ds.Tables[1].Rows.Count), 0));
                };
                htmlContent += "</tbody>";
                htmlContent += "<tfoot>";
                htmlContent += "<tr>";
                htmlContent += "<td style = 'padding: 8px; text-align: left;  border-top: 1px solid #ddd;font-weight: bold;'> Total: " + distinctDates.Count + "Days</td>";
                htmlContent += "<td style = 'padding: 8px; text-align: left; border-top: 1px solid #ddd;font-weight: bold;' > </td>";
                htmlContent += "<td style = 'padding: 8px; text-align: left; border-top: 1px solid #ddd;font-weight: bold;' > </td>";
                htmlContent += "<td style = 'padding: 8px; text-align: left; border-top: 1px solid #ddd;font-weight: bold;' > </td>";
                htmlContent += "<td style = 'padding: 8px; text-align: left; border-top: 1px solid #ddd;font-weight: bold;' >Avg. " + AvgFineLeaf + "% </td>";
                htmlContent += "<td style = 'padding: 8px; text-align: center; border-top: 1px solid #ddd;font-weight: bold;' >" + TotalChallanWeight + " </td>";
                htmlContent += "<td style = 'padding: 8px; text-align: left; border-top: 1px solid #ddd;font-weight: bold;' >" + AvgRate + " </td>";
                htmlContent += "<td style = 'padding: 8px; text-align: right; border-top: 1px solid #ddd;font-weight: bold;' >" + TotalAmount + " </td>";
                htmlContent += "</tr>";
                htmlContent += "</tfoot>";
            }
            htmlContent += "</table>";

            htmlContent += "<div style = 'text-align: center; margin-bottom: 8px;'>";
            htmlContent += "<h6> Payment Data </h6>";
            htmlContent += "</div>";

            htmlContent += "<table style = 'width: 100%; border-collapse: collapse;'>";
            htmlContent += "<thead>";
            htmlContent += "<tr>";
            htmlContent += "<th style = 'padding: 4px; text-align: left; border-bottom: 1px solid #ddd;' > Pay Date </th>";
            htmlContent += "<th style = 'padding: 4px; text-align: left; border-bottom: 1px solid #ddd;' > Naration </th>";
            htmlContent += "<th style = 'padding: 4px; text-align: right; border-bottom: 1px solid #ddd;' > Amount </th>";

            htmlContent += "</tr><hr/>";
            htmlContent += "</thead>";
            htmlContent += "<tbody>";

            decimal TotalPayAmount = 0;

            if (ds.Tables[2].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[2].Rows)
                {
                    htmlContent += "<tr>";
                    htmlContent += "<td style = 'padding: 4px;margin:1px; text-align: left; ' >" + Convert.ToString(row["CollectionDate"]) + " </td>";
                    htmlContent += "<td style = 'padding: 4px;margin:1px; text-align: left; ' > " + Convert.ToString(row["Narration"]) + " </td>";
                    htmlContent += "<td style = 'padding: 4px;margin:1px; text-align: right; ' > " + Convert.ToString(row["Amount"]) + " </td>";

                    htmlContent += "</tr>";

                    TotalPayAmount += decimal.TryParse(Convert.ToString(row["Amount"]), out decimal totalPay) ? totalPay : 0;

                };
                htmlContent += "</tbody>";
                htmlContent += "<tfoot>";
                htmlContent += "<tr>";
                htmlContent += "<td style = 'padding: 8px; text-align: left; border-top: 1px solid #ddd; font-weight: bold;'> Total </td>";
                htmlContent += "<td style = 'padding: 8px; text-align: left; border-top: 1px solid #ddd;' > </td>";
                htmlContent += "<td style = 'padding: 8px; text-align: right; border-top: 1px solid #ddd; font-weight: bold;' >" + TotalPayAmount + " </td>";

                htmlContent += "</tr>";
                htmlContent += "</tfoot>";
            }
            htmlContent += "</table>";

            htmlContent += "<div style = 'margin: 20px auto; heigth:120px; max-width: 100px; padding: 20px; border: 1px solid #ccc; background-color: #FFFFFF; font-family: Arial, sans-serif;' >";
            htmlContent += "<table style = 'width: 100%; border-collapse: collapse;'>";

            htmlContent += "<tbody>";
            htmlContent += "<tr>";
            htmlContent += "<td style = 'margin: 0; text-align: left;font-weight: bold;' > Standing Season Advance :</td>";
            htmlContent += "<td style = 'margin: 0; text-align: right; font-weight: bold;' > " + StandingSeasonAdv + " </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > </td>";
            htmlContent += "<td style = 'margin: 0; text-align: right; font-weight: bold;'  ></td>";
            htmlContent += "</tr>";
            htmlContent += "<tr>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > Commission :</td>";
            htmlContent += "<td style = 'margin: 0; text-align: right;font-weight: bold;' > " + CommisonAmount + "</td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' ></td>";
            htmlContent += "<td style = 'margin: 0; text-align: right;font-weight: bold;'  > </td>";
            htmlContent += "</tr>";
            htmlContent += "<tr>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > Less Previous Due :</td>";
            htmlContent += "<td style = 'margin: 0; text-align: right; font-weight: bold;' >" + PrevousAmount + " </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' ></td>";
            htmlContent += "<td style = 'margin: 0; text-align: left; font-weight: bold;'  ></td>";
            htmlContent += "</tr>";
            htmlContent += "<tr>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' >Less GI Cess :</td>";
            htmlContent += "<td style = 'margin: 0; text-align: right; font-weight: bold;' > " + Cess + " </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > </td>";
            htmlContent += "<td style = 'margin: 0; text-align: right; font-weight: bold;'  ></td>";
            htmlContent += "</tr>";
            htmlContent += "<tr>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > Less Season Adv. :</td>";
            htmlContent += "<td style = 'margin: 0; text-align: right; font-weight: bold;' > " + LessSeasonAdv + " </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > Amount To be Paid: </td>";
            htmlContent += "<td style = 'margin: 0; text-align: right; font-weight: bold;'  >" + AmountToPay + "</td>";
            htmlContent += "</tr>";
            htmlContent += "<tr>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > </td>";
            htmlContent += "<td style = 'margin: 0; text-align: right; font-weight: bold;' >  </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > Round Off: </td>";
            htmlContent += "<td style = 'margin: 0; text-align: right; font-weight: bold;'  >" + RoundAmountToPay + "</td>";
            htmlContent += "</tr>";

            //htmlContent += "<tr>";

            //htmlContent += "<td style = 'margin: 0; text-align: left; font-weight: bold;'  > In word " + NumberToWordConvertor.ConvertToWords(Convert.ToInt64(RoundAmountToPay)) + " Only </td>";
            //htmlContent += "</tr>";
            htmlContent += "<tr>";

            htmlContent += "<td colspan='4' style = 'margin: 0; text-align: left; font-weight: bold;'  >In word " + NumberToWordConvertor.ConvertToWords(Convert.ToInt64(RoundAmountToPay)) + " Only </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left; ' >  </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > </td>";
            htmlContent += "<td style = 'margin: 0; text-align: left;' > </td>";
            htmlContent += "<td style = 'margin: 0; text-align: right; font-weight: bold;'  ></td>";
            htmlContent += "</tr>";

            htmlContent += "</tbody>";
            htmlContent += "</table>";
            htmlContent += "</div>";
            htmlContent += "<br>";

            htmlContent += "<table style = 'width: 100%; border-collapse: collapse;'>";
            htmlContent += "<tbody>";
            htmlContent += "<tr>";
            htmlContent += "<td style = 'margin: 0; text-align: left;font-weight: bold;' >Check & Verified </td>";
            htmlContent += "<td style = 'margin: 0; text-align: right; font-weight: bold;'  >Recived Signature</td>";
            htmlContent += "</tr>";

            htmlContent += "</tbody>";
            htmlContent += "</table>";

            htmlContent += "</div>";
            htmlContent += "<h7> Report Genearate on :" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "</h7>";

            PdfGenerator.AddPdfPages(data, htmlContent, PageSize.A4);



            byte[]? response = null;
            using (MemoryStream ms = new MemoryStream())
            {
                data.Save(ms);
                response = ms.ToArray();
            }

            return response;
        }

        async Task<string> IPrintRepository.WhatsAppMessage(WhatsAppModel message)
        {
            return await _whatsAppService.SendWhatsAppMessageAsync(message.ToPhoneNumber, message.Message);
        }
    }
}
