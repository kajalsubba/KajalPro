using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Api.Entity.Common;
using Tea.Api.Entity.MessageBroker;
using Tea.Api.Entity.Print;

namespace Tea.Api.Service.GoogleSheet
{
    public interface IGoogleSheetsService
    {
        Task<string> AddAppointmentData(string sheetName, IList<object> rowData);

    }
}
