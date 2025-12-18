using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Api.Entity.Print;

namespace Tea.Api.Service.GoogleSheet
{
    public class GoogleSheetsService : IGoogleSheetsService
    {
        private readonly string _credentialsPath;
        private readonly string _spreadsheetId;

        public GoogleSheetsService(IConfiguration config)
        {
            _spreadsheetId = config["GoogleSheet:SpreadSheetId"];
            _credentialsPath = config["GoogleSheet:JsonFileName"];
        }

        async Task<string> IGoogleSheetsService.AddAppointmentData(string sheetName, IList<object> rowData)
        {
            var service = CreateSheetsService();
            var range = $"{sheetName}!A:Z";

            var valueRange = new ValueRange
            {
                Values = new List<IList<object>> { rowData }
            };

            var request = service.Spreadsheets.Values.Append(valueRange, _spreadsheetId, range);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;

            var response = await request.ExecuteAsync();
            return response.Updates?.UpdatedRange;
        }

        private SheetsService CreateSheetsService()
        {
            GoogleCredential credential;

            using (var stream = new FileStream(_credentialsPath, FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream)
                    .CreateScoped(SheetsService.Scope.Spreadsheets);
            }

            return new SheetsService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "Z Finance"
            });
        }

    }
}
