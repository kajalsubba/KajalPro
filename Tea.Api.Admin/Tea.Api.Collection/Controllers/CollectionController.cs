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

        [HttpPost, Route("SaveApproveStg")]
        public async Task<IActionResult> SaveApproveStg([FromBody] SaveApproveStg _input)
        {
            var results = await _collectionService.SaveApproveStg(_input);
            return (results != null) ? Ok(results) : throw new Exception();
        }

        [HttpPost, Route("SaveSale")]
        public async Task<IActionResult> SaveSale([FromBody] SaveSaleModel _input)
        {
            var results = await _collectionService.SaveSale(_input);
            return (results != null) ? Ok(results) : throw new Exception();
        }

        [HttpPost, Route("GetSaleDetails")]
        public async Task<IActionResult> GetSaleDetails([FromBody] SelectSale _input)
        {
            var results = await _collectionService.GetSaleDetails(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Newtonsoft.Json.Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }
    }
}
