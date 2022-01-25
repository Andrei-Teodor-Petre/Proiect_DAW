using Microsoft.AspNetCore.Mvc;

namespace QuertyKey_DAW.Controllers
{
    [ApiController]
    [Route("Accessory")]
    public class AccesoriesController : BaseController
    {
        public AccesoriesController(UnitOfWork.UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        [HttpGet]
        [Route("List")]
        public IActionResult GetListedItems()
        {
            
            return Ok();
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult AddItem()
        {
            return Ok();
        }

        [HttpPost]
        [Route("Item")]
        public IActionResult GetItem()
        {
            return Ok();
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult UpdateItem()
        {
            return Ok();
        }

        [HttpDelete]
        [Route("Remove")]
        public IActionResult RemoveItem()
        {
            return Ok();
        }



    }
}
