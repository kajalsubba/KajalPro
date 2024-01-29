using Microsoft.AspNetCore.Mvc;
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


    }
}
