using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
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
    [EnableCors("AllowSpecificOrigins")]

    public class AccountsController : ControllerBase
    {
        readonly IAccountsService _accountsService;

        public AccountsController(IAccountsService accountsService)
        {
            _accountsService = accountsService;
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
        [HttpPost, Route("GetEntrySeasonAdvance")]
        public async Task<IActionResult> GetEntrySeasonAdvance([FromBody] GetSeasonAdvanceModel _input)
        {
            var results = await _accountsService.GetEntrySeasonAdvance(_input);
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

        [HttpPost, Route("GetStgBillHistory")]
        public async Task<IActionResult> GetStgBillHistory([FromBody] GetSTGBillHistoryModel _input)
        {
            var results = await _accountsService.GetStgBillHistory(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }
        [HttpPost, Route("GetStgSummary")]
        public async Task<IActionResult> GetStgSummary([FromBody] StgSummaryModel _input)
        {
            var results = await _accountsService.GetStgSummary(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

        [HttpPost, Route("GetSaleSummary")]
        public async Task<IActionResult> GetSaleSummary([FromBody] SaleSummaryModel _input)
        {
            var results = await _accountsService.GetSaleSummary(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

        [HttpPost, Route("GetSupplierSummary")]
        public async Task<IActionResult> GetSupplierSummary([FromBody] SupplierSummaryModel _input)
        {
            var results = await _accountsService.GetSupplierSummary(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }


        [HttpPost, Route("GetSupplierBillData")]
        public async Task<IActionResult> GetSupplierBillData([FromBody] SupplierBillModel _input)
        {
            var results = await _accountsService.GetSupplierBillData(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }


        [HttpPost, Route("SaveSupplierBill")]
        public async Task<IActionResult> SaveSupplierBill([FromBody] SaveSupplierBill _input)
        {
            var results = await _accountsService.SaveSupplierBill(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

        [HttpPost, Route("GetSupplierBillHistory")]
        public async Task<IActionResult> GetSupplierBillHistory([FromBody] GetSupplierBillHistoryModel _input)
        {
            var results = await _accountsService.GetSupplierBillHistory(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

        [HttpPost, Route("GetSmartHistory")]
        public async Task<IActionResult> GetSmartHistory([FromBody] SmartHistoryModel _input)
        {
            var results = await _accountsService.GetSmartHistory(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

        [HttpPost, Route("GetNarration")]
        public async Task<IActionResult> GetNarration([FromBody] NarrationModel _input)
        {
            var results = await _accountsService.GetNarration(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

        #region wallet
        [HttpPost, Route("SaveUserWallet")]
        public async Task<IActionResult> SaveUserWallet([FromBody] WalletModel _input)
        {
            var results = await _accountsService.SaveUserWallet(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

        [HttpPost, Route("GetWalletHistory")]
        public async Task<IActionResult> GetWalletHistory([FromBody] WalletHistModel _input)
        {
            var results = await _accountsService.GetWalletHistory(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

        [HttpPost, Route("GetWalletBalanace")]
        public async Task<IActionResult> GetWalletBalanace([FromBody] WalletBalanceModel _input)
        {
            var results = await _accountsService.GetWalletBalanace(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

        [HttpPost, Route("GetWalletStatement")]
        public async Task<IActionResult> GetWalletStatement([FromBody] WalletHistModel _input)
        {
            var results = await _accountsService.GetWalletStatement(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

        [HttpPost, Route("SavePettyCashBook")]
        public async Task<IActionResult> SavePettyCashBook([FromBody] PettyCashBookModel _input)
        {
            var results = await _accountsService.SavePettyCashBook(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

        [HttpPost, Route("GetPettyCashBoook")]
        public async Task<IActionResult> GetPettyCashBoook([FromBody] WalletHistModel _input)
        {
            var results = await _accountsService.GetPettyCashBoook(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

        #endregion
    }
}
