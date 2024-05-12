using Microsoft.Extensions.Configuration;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using System.Data;
using Tea.Api.Data.Common;
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
            <title>Table with Borders</title>
            <style>
                table {
                    border-collapse: collapse;
                    width: 100%;
                }
                th, td {
                    border: 1px solid black;
                    padding: 8px;
                    text-align: left;
                }
                th {
                    background-color: #f2f2f2; /* Gray background color for table headers */
                }
            </style>
            </head>
            <body>
            <table>
              <tr>
                <th>Firstname</th>
                <th>Lastname</th>
                <th>Age</th>
              </tr>
              <tr>
                <td>John</td>
                <td>Doe</td>
                <td>30</td>
              </tr>
              <tr>
                <td>Jane</td>
                <td>Smith</td>
                <td>25</td>
              </tr>
              <tr>
                <td>Bob</td>
                <td>Johnson</td>
                <td>40</td>
              </tr>
            </table>
            </body>
            </html>";

            //PdfGenerator.AddPdfPages(data, htmlContent, PageSize.A4);
            //byte[]? response = null;
            //using (MemoryStream ms = new MemoryStream())
            //{
            //    data.Save(ms);
            //    response = ms.ToArray();
          //  }
          //  string fileName = "FeesStructure" + req.date + ".pdf";
               DataTable firstTable = ds.Tables[0];
            using (MemoryStream stream = new MemoryStream())
            {
                using (PdfDocument document = new PdfDocument())
                {
                    foreach (DataTable table in ds.Tables)
                    {
                        PdfPage page = document.AddPage();
                        XGraphics gfx = XGraphics.FromPdfPage(page);
                        if (PdfSharp.Fonts.GlobalFontSettings.FontResolver is null)
                        {
                            GlobalFontSettings.FontResolver = new CustomFontResolver();
                        }
                        XFont font = new XFont("Arial", 10,XFontStyleEx.Regular);

                        int currentY = 20;

                        // Print column headers
                        foreach (DataColumn column in table.Columns)
                        {
                            gfx.DrawString(column.ColumnName, font, XBrushes.Black, new XPoint(20, currentY));
                            currentY += 20;
                        }

                        // Print data
                        foreach (DataRow row in table.Rows)
                        {
                            currentY += 10;
                            foreach (DataColumn column in table.Columns)
                            {
                                gfx.DrawString(row[column].ToString(), font, XBrushes.Black, new XPoint(20, currentY));
                                currentY += 20;
                            }
                        }
                    }

                    document.Save(stream);
                }

            return stream.ToArray();
            }
        }
    }
}
