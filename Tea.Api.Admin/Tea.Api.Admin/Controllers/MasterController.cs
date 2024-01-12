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

        [HttpPost, Route("SaveCategory")]
        public async Task<IActionResult> SaveCategory([FromBody] SaveCategoryModel _input)
        {
            var results = await _adminService.SaveCategory(_input);
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

        [HttpPost, Route("GetClient")]
        public async Task<IActionResult> GetClient([FromBody] CommonSelectModel _input)
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

        [HttpPost, Route("GetFactoryAccount")]
        public async Task<IActionResult> GetFactoryAccount([FromBody] CommonSelectModel _input)
        {
            var results = await _adminService.GetFactoryAccount(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }
    }
}
