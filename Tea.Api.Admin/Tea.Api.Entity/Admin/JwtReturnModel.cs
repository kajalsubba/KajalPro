﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Entity.Admin
{
    public class JwtReturnModel
    {
        public string? token { get;set; }
        public DateTime? expiration { get;set; }
    }
}
