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

        [HttpPost, Route("GradeReport")]
        public async Task<IActionResult> GradeReport([FromBody] GradeReportModel _input)
        {
            var results = await _collectionService.GradeReport(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Newtonsoft.Json.Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }
    }
}
