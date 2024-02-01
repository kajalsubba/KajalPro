using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Xml;
using Tea.Api.Entity.Admin;
using Tea.Api.Entity.Collection;
using Tea.Api.Service.Collection;

namespace Tea.Api.Collection.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CollectionController : ControllerBase
    {
        readonly ICollectionService _collectionService;

        public CollectionController(ICollectionService collectionService)
        {
            _collectionService=collectionService;
        }

        [HttpPost, Route("SaveStg")]
        public async Task<IActionResult> SaveStg([FromBody] SaveStgModel _input)
        {
            var results = await _collectionService.SaveSTG(_input);
            return (results != null) ? Ok(results) : throw new Exception();
        }

        [HttpPost, Route("GetStgPendingData")]
        public async Task<IActionResult> GetStgPendingData([FromBody] StgFilterModel _input)
        {
            var results = await _collectionService.GetStgPendingData(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Newtonsoft.Json.Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }


    }
}
