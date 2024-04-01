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


        [HttpPost, Route("SaveSupplier")]
        public async Task<IActionResult> SaveSupplier([FromBody] SaveSupplierModel _input)
        {
            var results = await _collectionService.SaveSupplier(_input);
            return (results != null) ? Ok(results) : throw new Exception();
        }


        [HttpPost, Route("UploadSupplierChallan")]
        public async Task<IActionResult> UploadSupplierChallan([FromForm] SaveChallanImageModel _input)
        {
            var results = await _collectionService.UploadSupplierChallan(_input);
            return (results != null) ? Ok(results) : throw new Exception();
        }

        [HttpPost, Route("GetSupplierDetails")]
        public async Task<IActionResult> GetSupplierDetails([FromBody] SupplierFilterModel _input)
        {
            var results = await _collectionService.GetSupplierDetails(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Newtonsoft.Json.Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

        [HttpPost, Route("SaveApproveSupplier")]
        public async Task<IActionResult> SaveApproveSupplier([FromBody] SaveApproveSupplier _input)
        {
            var results = await _collectionService.SaveApproveSupplier(_input);
            return (results != null) ? Ok(results) : throw new Exception();
        }

        [HttpPost, Route("GetStgRateFixData")]
        public async Task<IActionResult> GetStgRateFixData([FromBody] GetStgRateFixModel _input)
        {
            var results = await _collectionService.GetStgRateFixData(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Newtonsoft.Json.Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

        [HttpPost, Route("GetSupplierRateFixData")]
        public async Task<IActionResult> GetSupplierRateFixData([FromBody] GetSupplierRateFixModel _input)
        {
            var results = await _collectionService.GetSupplierRateFixData(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Newtonsoft.Json.Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

        [HttpPost, Route("SaveStgRate")]
        public async Task<IActionResult> SaveStgRate([FromBody] SaveStgRateFixModel _input)
        {
            var results = await _collectionService.SaveStgRate(_input);
            return (results != null) ? Ok(results) : throw new Exception();
        }

        [HttpPost, Route("SaveStgSale")]
        public async Task<IActionResult> SaveStgSale([FromBody] SaveStgSaleModel _input)
        {
            var results = await _collectionService.SaveStgSale(_input);
            return (results != null) ? Ok(results) : throw new Exception();
        }

        [HttpPost, Route("GetSupplierVehicle")]
        public async Task<IActionResult> GetSupplierVehicle([FromBody] GetSupplierVehicleModel _input)
        {
            var results = await _collectionService.GetSupplierVehicle(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Newtonsoft.Json.Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

        [HttpPost, Route("SaveSupplierRate")]
        public async Task<IActionResult> SaveSupplierRate([FromBody] SaveSupplierRateFixModel _input)
        {
            var results = await _collectionService.SaveSupplierRate(_input);
            return (results != null) ? Ok(results) : throw new Exception();
        }

        [HttpPost, Route("GetStgVehicleData")]
        public async Task<IActionResult> GetStgVehicleData([FromBody] GetStgVehicleModel _input)
        {
            var results = await _collectionService.GetStgVehicleData(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Newtonsoft.Json.Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

        [HttpPost, Route("GetStgPendingDate")]
        public async Task<IActionResult> GetStgPendingDate([FromBody] GetStgPendingDateModel _input)
        {
            var results = await _collectionService.GetStgPendingDate(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Newtonsoft.Json.Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }

        [HttpPost, Route("GetSupplierDefaultData")]
        public async Task<IActionResult> GetSupplierDefaultData([FromBody] GetSupplierDefaultModel _input)
        {
            var results = await _collectionService.GetSupplierDefaultData(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Newtonsoft.Json.Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }
        [HttpPost, Route("GetNotifications")]
        public async Task<IActionResult> GetNotifications([FromBody] NotificationModel _input)
        {
            var results = await _collectionService.GetNotifications(_input);
            string JsonResult;
            JsonResult = JsonConvert.SerializeObject(results, Newtonsoft.Json.Formatting.Indented);
            return (results != null) ? Ok(JsonResult) : throw new Exception();
        }
    }
}
