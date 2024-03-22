﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tea.Api.Entity.Accounts;
using Tea.Api.Entity.Admin;
using Tea.Api.Entity.Collection;
using Tea.Api.Service.Accounts;
using Tea.Api.Service.Collection;

namespace Tea.Api.Accounts.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : ControllerBase
    {
        readonly IAccountsService _accountsService;

        public AccountsController(IAccountsService accountsService)
        {
            _accountsService=accountsService;
        }

        

        [HttpPost, Route("SaveSeasonAdvance")]
        public async Task<IActionResult> SaveSeasonAdvance([FromBody] SaveSeasonAdvanceModel _input)
        {
            var results = await _accountsService.SaveSeasonAdvance(_input);
            return (results != null) ? Ok(results) : throw new Exception();
        }

        [HttpPost, Route("GetSeasonAdvance")]
        public async Task<IActionResult> GetSeasonAdvance([FromBody] GetSeasonAdvanceModel _input)
        {
            var results = await _accountsService.GetSeasonAdvance(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }


        [HttpPost, Route("SavePayment")]
        public async Task<IActionResult> SavePayment([FromBody] SavePaymentModel _input)
        {
            var results = await _accountsService.SavePayment(_input);
            return (results != null) ? Ok(results) : throw new Exception();
        }
        [HttpPost, Route("GetPaymentData")]
        public async Task<IActionResult> GetPaymentData([FromBody] GetPaymentModel _input)
        {
            var results = await _accountsService.GetPaymentData(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

        [HttpPost, Route("GetStgBillData")]
        public async Task<IActionResult> GetStgBillData([FromBody] StgBillModel _input)
        {
            var results = await _accountsService.GetStgBillData(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

        [HttpPost, Route("SaveStgBill")]
        public async Task<IActionResult> SaveStgBill([FromBody] SaveStgBill _input)
        {
            var results = await _accountsService.SaveStgBill(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

    }
}
