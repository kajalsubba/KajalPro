using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tea.Api.Entity.Collection;
using Tea.Api.Service.Collection;

namespace Tea.Api.Collection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleController : ControllerBase
    {
        readonly ICollectionService _collectionService;

        public SaleController(ICollectionService collectionService)
        {
            _collectionService = collectionService;
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

        [HttpPost, Route("GetSaleRateFixData")]
        public async Task<IActionResult> GetSaleRateFixData([FromBody] GetSaleRateFixModel _input)
        {
            var results = await _collectionService.GetSaleRateFixData(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Newtonsoft.Json.Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

        [HttpPost, Route("SaveSaleRate")]
        public async Task<IActionResult> SaveSaleRate([FromBody] SaveSaleRateFixModel _input)
        {
            var results = await _collectionService.SaveSaleRate(_input);
            return (results != null) ? Ok(results) : throw new Exception();
        }

        [HttpPost, Route("GetSaleStgData")]
        public async Task<IActionResult> GetSaleStgData([FromBody] GetSaleStgxModel _input)
        {
            var results = await _collectionService.GetSaleStgData(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Newtonsoft.Json.Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }
        [HttpPost, Route("GetSaleSupplierData")]
        public async Task<IActionResult> GetSaleSupplierData([FromBody] GetSaleStgxModel _input)
        {
            var results = await _collectionService.GetSaleSupplierData(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Newtonsoft.Json.Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

        [HttpPost, Route("GetSaleFactory")]
        public async Task<IActionResult> GetSaleFactory([FromBody] GetSaleFactory _input)
        {
            var results = await _collectionService.GetSaleFactory(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Newtonsoft.Json.Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }
        [HttpPost, Route("GetSaleRateFixFactory")]
        public async Task<IActionResult> GetSaleRateFixFactory([FromBody] GetSaleRateFixFactory _input)
        {
            var results = await _collectionService.GetSaleRateFixFactory(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Newtonsoft.Json.Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

    }
}
