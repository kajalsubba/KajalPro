using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tea.Api.Entity.Admin;
using Tea.Api.Service.Admin;

namespace Tea.Api.Admin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MasterController : ControllerBase
    {

        readonly IAdminService _adminService;

        public MasterController(IAdminService adminService)
        {
            _adminService = adminService;
        }


        [HttpPost, Route("GetFinancialYear")]
        public async Task<IActionResult> GetFinancialYear([FromBody] SelectFinancialYear _input)
        {
            var results = await _adminService.GetFinancialYear(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

        [HttpPost, Route("SaveCategory")]
        public async Task<IActionResult> SaveCategory([FromBody] SaveCategoryModel _input)
        {
            var results = await _adminService.SaveCategory(_input);
            return (results != null) ? Ok(results) : throw new Exception();
        }

        [HttpPost, Route("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory([FromBody] DeleteCategoryModel _input)
        {
            var results = await _adminService.DeleteCategory(_input);
            return (results != null) ? Ok(results) : throw new Exception();
        }

        [HttpPost, Route("GetCategory")]
        public async Task<IActionResult> GetCategory([FromBody] CommonSelectModel _input)
        {
            var results = await _adminService.GetCategory(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

        [HttpPost, Route("SaveClient")]
        public async Task<IActionResult> SaveClient([FromBody] SaveClientModel _input)
        {
            var results = await _adminService.SaveClient(_input);
            return (results != null) ? Ok(results) : throw new Exception();
        }

        [HttpPost, Route("UpdateClientPassword")]
        public async Task<IActionResult> UpdateClientPassword([FromBody] PasswordUpdateClientModel _input)
        {
            var results = await _adminService.UpdateClientPassword(_input);
            return (results != null) ? Ok(results) : throw new Exception();
        }

        [HttpPost, Route("DeleteClient")]
        public async Task<IActionResult> DeleteClient([FromBody] DeleteClientModel _input)
        {
            var results = await _adminService.DeleteClient(_input);
            return (results != null) ? Ok(results) : throw new Exception();
        }


        [HttpPost, Route("GetClient")]
        public async Task<IActionResult> GetClient([FromBody] SelectCategoryClientModel _input)
        {
            var results = await _adminService.GetClient(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }


        [HttpPost, Route("SaveGrade")]
        public async Task<IActionResult> SaveGrade([FromBody] SaveGradeModel _input)
        {
            var results = await _adminService.SaveGrade(_input);
            return (results != null) ? Ok(results) : throw new Exception();
        }

        [HttpPost, Route("SaveSupplierTarget")]
        public async Task<IActionResult> SaveSupplierTarget([FromBody] TargetModel _input)
        {
            var results = await _adminService.SaveSupplierTarget(_input);
            return (results != null) ? Ok(results) : throw new Exception();
        }

        [HttpPost, Route("DeleteGrade")]
        public async Task<IActionResult> DeleteGrade([FromBody] DeleteGradeModel _input)
        {
            var results = await _adminService.DeleteGrade(_input);
            return (results != null) ? Ok(results) : throw new Exception();
        }


        [HttpPost, Route("GetGrade")]
        public async Task<IActionResult> GetGrade([FromBody] CommonSelectModel _input)
        {
            var results = await _adminService.GetGrade(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

        [HttpPost, Route("SaveFactory")]
        public async Task<IActionResult> SaveFactory([FromBody] SaveFactoryModel _input)
        {
            var results = await _adminService.SaveFactory(_input);
            return (results != null) ? Ok(results) : throw new Exception();
        }

        [HttpPost, Route("DeleteFactory")]
        public async Task<IActionResult> DeleteFactory([FromBody] DeleteFactoryModel _input)
        {
            var results = await _adminService.DeleteFactory(_input);
            return (results != null) ? Ok(results) : throw new Exception();
        }


        [HttpPost, Route("GetFactory")]
        public async Task<IActionResult> GetFactory([FromBody] CommonSelectModel _input)
        {
            var results = await _adminService.GetFactory(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

        [HttpPost, Route("SaveFactoryAccount")]
        public async Task<IActionResult> SaveFactoryAccount([FromBody] SaveAccountModel _input)
        {
            var results = await _adminService.SaveFactoryAccount(_input);
            return (results != null) ? Ok(results) : throw new Exception();
        }
        [HttpPost, Route("DeleteFactoryAccount")]
        public async Task<IActionResult> DeleteFactoryAccount([FromBody] DeleteAccountModel _input)
        {
            var results = await _adminService.DeleteFactoryAccount(_input);
            return (results != null) ? Ok(results) : throw new Exception();
        }

        [HttpPost, Route("GetFactoryAccount")]
        public async Task<IActionResult> GetFactoryAccount([FromBody] CommonSelectModel _input)
        {
            var results = await _adminService.GetFactoryAccount(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

        [HttpPost, Route("SaveVehicle")]
        public async Task<IActionResult> SaveVehicle([FromBody] SaveVehicleModel _input)
        {
            var results = await _adminService.SaveVehicle(_input);
            return (results != null) ? Ok(results) : throw new Exception();
        }
        [HttpPost, Route("GetVehicle")]
        public async Task<IActionResult> GetVehicle([FromBody] CommonSelectModel _input)
        {
            var results = await _adminService.GetVehicle(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

        [HttpPost, Route("GetClientList")]
        public async Task<IActionResult> GetClientList([FromBody] SelectCategoryClientModel _input)
        {
            var results = await _adminService.GetClientList(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }



        [HttpPost, Route("SaveCompany")]
        public async Task<IActionResult> SaveCompany([FromForm] SaveCompanyModel _input)
        {
            var results = await _adminService.SaveCompany(_input);
            return (results != null) ? Ok(results) : throw new Exception();
        }



        [HttpPost, Route("GetCompany")]
        public async Task<IActionResult> GetCompany([FromBody] GetCompanyModel _input)
        {
            var results = await _adminService.GetCompany(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }


        [HttpGet, Route("GetTrip")]
        public async Task<IActionResult> GetTrip()
        {
            var results = await _adminService.GetTrip();
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

        [HttpGet, Route("GetSaleType")]
        public async Task<IActionResult> GetSaleType()
        {
            var results = await _adminService.GetSaleType();
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }


        [HttpPost, Route("GetPaymentType")]
        public async Task<IActionResult> GetPaymentType([FromBody] GetPaymentTypeModel _input)
        {
            var results = await _adminService.GetPaymentType(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

        [HttpPost, Route("SavePaymentType")]
        public async Task<IActionResult> SavePaymentType([FromBody] SavePaymentTypeModel _input)
        {
            var results = await _adminService.SavePaymentType(_input);
            return (results != null) ? Ok(results) : throw new Exception();
        }



        [HttpPost, Route("SaveFinancialYear")]
        public async Task<IActionResult> SaveFinancialYear([FromBody] FinancialYearModel _input)
        {
            var results = await _adminService.SaveFinancialYear(_input);
            return (results != null) ? Ok(results) : throw new Exception();
        }
    }
}
