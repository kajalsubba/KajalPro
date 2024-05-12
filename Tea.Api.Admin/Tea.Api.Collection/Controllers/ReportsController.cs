using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tea.Api.Entity.Collection;
using Tea.Api.Service.Collection;

namespace Tea.Api.Collection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportsController : ControllerBase
    {

        readonly ICollectionService _collectionService;

        public ReportsController(ICollectionService collectionService)
        {
            _collectionService = collectionService;
        }

        [HttpPost, Route("ClientWiseGradeReport")]
        public async Task<IActionResult> ClientWiseGradeReport([FromBody] GradeReportModel _input)
        {
            var results = await _collectionService.ClientWiseGradeReport(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Newtonsoft.Json.Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

        [HttpPost, Route("DateWiseGradeReport")]
        public async Task<IActionResult> DateWiseGradeReport([FromBody] GradeReportModel _input)
        {
            var results = await _collectionService.DateWiseGradeReport(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Newtonsoft.Json.Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }
    }
}
