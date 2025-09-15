using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Collection
{
    public class GradeReportModel
    {
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public long? TenantId { get; set; }
    }

    public class SeasonAdvReportModel
    {
        public long? TenantId { get; set; }
        public string? Category { get; set; }

    }

    public class AnalysisReportModel
    {
        public long? TenantId { get; set; }
        public long? FinancialYearId { get; set; }

    }
}
