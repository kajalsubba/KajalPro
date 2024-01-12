using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Xml;
using Tea.Api.Entity.Admin;
using Tea.Api.Service.Admin;

namespace Tea.Api.Admin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService=adminService;
        }
        [HttpPost, Route("SaveUser")]
        public async Task<IActionResult> SaveUser([FromBody] SaveUserModel _input)
        {
            var results = await _adminService.SaveUser(_input);
            return (results != null) ? Ok(results) : throw new Exception();
        }

        [HttpPost, Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel _input)
        {
            var results = await _adminService.Login(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Newtonsoft.Json.Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }
    }
}
