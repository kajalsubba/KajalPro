
using PdfSharpCore;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System.Data;
using Tea.Api.Data.DbHandler;
using Tea.Api.Entity.Print;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace Tea.Api.Data.Repository.Print
{
    public class PrintRepository : IPrintRepository
    {

        readonly IDataHandler _dataHandler;

        public PrintRepository(IDataHandler dataHandler)
        {
            _dataHandler = dataHandler;

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

            var data = new PdfDocument();
            string htmlContent = @"<!DOCTYPE html>
<html lang=""en"">
<head>
<meta charset=""UTF-8"">
<meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
<title>Two Divs Side by Side</title>
<style>
  h1 {
    text-align: center; /* Center align the text */
    font-size: 14px; /* Set font size to 14px */
    padding: 10px; /* Add padding for better spacing */
  }
  /* Style for left and right divs */
  .left-div {
    width: 30%; /* First div takes 30% of the width */
    float: left; /* Float div to the left */
    box-sizing: border-box; /* Include padding and border in the div's total width */
    padding: 20px; /* Adding some padding for better readability */
    border: 1px solid black; /* Add a solid black border */
    height: 150px;
  }
  
  .right-div {
    width: 70%; /* Second div takes 70% of the width */
    float: left; /* Float div to the left */
    box-sizing: border-box; /* Include padding and border in the div's total width */
    padding: 20px; /* Adding some padding for better readability */
    border: 1px solid black; /* Add a solid black border */
    font-size: 14px; /* Reduce font size */
    height: 150px;
  }
</style>
</head>
<body>

<h1>Green Leaves Collection Statement</h1>

<!-- Left Div -->
<div class=""left-div"">
  <p>Udai Limbu</p>
  <p>Ketetong, Margherita, Dist. Tinsukia, Assam</p>
  <p>Phone No. 9435138530</p>
</div>

<!-- Right Div -->
<div class=""right-div"">
  <table style=""width: 100%;"">
    <tr>
      <td style=""width: 25%;"">For the period from:</td>
      <td style=""width: 25%;"">01-03-2024 to 31-03-2024</td>
      <td style=""width: 25%;"">Client Id:</td>
      <td style=""width: 25%;"">1400</td>
    </tr>
    <tr>
      <td style=""width: 25%;"">Client Name:</td>
      <td style=""width: 25%;"">Kajal Subba</td>
      <td style=""width: 25%;"">Category:</td>
      <td style=""width: 25%;"">STG</td>
    </tr>
    <tr>
      <td style=""width: 25%;"">Address:</td>
      <td style=""width: 25%;"">Bokakhat, Assam</td>
      <td style=""width: 25%;"">Contact No:</td>
      <td style=""width: 25%;"">7002500235</td>
    </tr>
  </table>
</div>

</body>
</html>

";
            PdfGenerator.AddPdfPages(data, htmlContent, PageSize.A4);

         

            byte[]? response = null;
            using (MemoryStream ms = new MemoryStream())
            {
                data.Save(ms);
                response = ms.ToArray();
            }
            // string fileName = "FeesStructure" + req.date + ".pdf";
            return response;
        }
 
    }
}
