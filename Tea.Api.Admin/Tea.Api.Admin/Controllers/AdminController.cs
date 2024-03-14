﻿using Microsoft.AspNetCore.Mvc;
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
            _adminService = adminService;
        }
        [HttpPost, Route("SaveUser")]
        public async Task<IActionResult> SaveUser([FromBody] SaveUserModel _input)
        {
            var results = await _adminService.SaveUser(_input);
            return (results != null) ? Ok(results) : throw new Exception();
        }
        [HttpPost, Route("GetUser")]
        public async Task<IActionResult> GetUser([FromBody] SelectUserModel _input)
        {
            var results = await _adminService.GetUser(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Newtonsoft.Json.Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

        [HttpPost, Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel _input)
        {
            var results = await _adminService.Login(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Newtonsoft.Json.Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

        [HttpPost, Route("SaveTenant")]
        public async Task<IActionResult> SaveTenant([FromBody] SaveTenantModel _input)
        {
            var results = await _adminService.SaveTenant(_input);
            return (results != null) ? Ok(results) : throw new Exception();
        }


        [HttpGet, Route("GetTenant")]
        public async Task<IActionResult> GetTenant()
        {
            var results = await _adminService.GetTenant();
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Newtonsoft.Json.Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }


        [HttpPost, Route("CreateRole")]
        public async Task<IActionResult> CreateRole([FromBody] SaveRoleModel _input)
        {
            var results = await _adminService.CreateRole(_input);
            return (results != null) ? Ok(results) : throw new Exception();
        }


        [HttpPost, Route("GetRole")]
        public async Task<IActionResult> GetRole([FromBody] GetRoleModel _input)
        {
            var results = await _adminService.GetRole(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Newtonsoft.Json.Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }


        [HttpPost, Route("ClientLogin")]
        public async Task<IActionResult> ClientLogin([FromBody] ClientLoginModel _input)
        {
            var results = await _adminService.ClientLogin(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Newtonsoft.Json.Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

        [HttpPost, Route("GetRolePermission")]
        public async Task<IActionResult> GetRolePermission([FromBody] RolePermission _input)
        {
            var results = await _adminService.GetRolePermission(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Newtonsoft.Json.Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

        [HttpPost, Route("SaveRolePermission")]
        public async Task<IActionResult> SaveRolePermission([FromBody] SaveRolePermissionModel _input)
        {
            var results = await _adminService.SaveRolePermission(_input);
            return (results != null) ? Ok(results) : throw new Exception();
        }

    }
}
