using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
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
        private IGoogleSheetsService _sheetsService;
        private readonly string _spreadsheetId;

        public GoogleSheetsService(IGoogleSheetsService sheetsService)
        {
            _sheetsService = sheetsService;
        }

        async Task<string> IGoogleSheetsService.AddAppointmentData(string sheetName, IList<object> rowData)
        {
            throw new NotImplementedException();
        }

        public SheetsService GetSheetsService(string spreadsheetId, string credentialsPath)
        {
            GoogleCredential credential;
            using (var stream = new FileStream(credentialsPath, FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream)
                    .CreateScoped(SheetsService.Scope.Spreadsheets);
            }

            var sheetsService = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "My .NET Core Sheets API",
            });

            return sheetsService;
        }

    }
}
