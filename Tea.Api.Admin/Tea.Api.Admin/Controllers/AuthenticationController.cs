using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tea.Api.Entity.Admin;
using Tea.Api.Service.Admin;

namespace Tea.Api.Admin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {

        readonly IAdminService _adminService;

        public AuthenticationController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost, Route("AuthenticationLogin")]
        public async Task<IActionResult> AuthenticationLogin([FromBody] LoginModel _input)
        {
            var results = await _adminService.AuthenticationLogin(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Newtonsoft.Json.Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }
    }
}
