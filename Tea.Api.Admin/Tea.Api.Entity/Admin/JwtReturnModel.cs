using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Admin
{
    public class JwtReturnModel
    {
        public string? Token { get; set; }
        public DateTime? Expiration { get; set; }
        public DataSet? Data { get; set; }
        public string? Message { get; set; }
    }
}
