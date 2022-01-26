using Microsoft.AspNetCore.Mvc;

namespace QuertyKey_DAW.Controllers
{
    [ApiController]
    [Route("Order")]
    public class OrdersController : BaseController
    {
        public OrdersController(UnitOfWork.UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }


        [HttpGet]
        [Route("List")]
        public IActionResult GetListedItems()
        {
            var items = this._unitOfWork.Orders.GetAll();
            this._unitOfWork.Complete();
            return Ok();
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult AddItem(FrontendModels.Order item)
        {

            try
            {
                if (this._unitOfWork.Orders.Find(it => it.Id == item.Id).Any())
                {
                    return BadRequest("Order already in registered");
                }
                var newItem = new DataModels.Order();
                //newItem.Switches = item.Switches.To;
                //newItem.Deskmats = item.Deskmats;
                //newItem.Specialties = item.Specialties;
                //newItem.Keyboards = item.Keyboards;
                //newItem.Merches = item.Merches;

                //TODO this needs some translation between Frontend models and DataModels

                this._unitOfWork.Orders.Add(newItem);

                var addedAcc = this._unitOfWork.Orders.Find(it => it.Id == newItem.Id).FirstOrDefault();
                return Ok(addedAcc);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("Item")]
        public IActionResult GetItem(FrontendModels.Order item)
        {
            try
            {
                var foundItem = this._unitOfWork.Orders.Find(it => it.Id == item.Id).FirstOrDefault();
                if (foundItem == null)
                {
                    return BadRequest("Cannot find the requested Order");
                }

                return Ok(foundItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult UpdateItem(FrontendModels.Order item)
        {
            try
            {
                var oldItem = this._unitOfWork.Orders.Find(it => it.Id == item.Id).FirstOrDefault();

                //oldItem.Name = item.Name;
                //oldItem.Description = item.Description;
                //oldItem.Quantity = item.Quantity;
                //oldItem.Price = item.Price;
                //oldItem.AddedOn = item.AddedOn;

                //TODO add after adding translation

                this._unitOfWork.Orders.Update(oldItem);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Remove")]
        public IActionResult RemoveItem(FrontendModels.Order item)
        {
            try
            {
                var deleteItem = this._unitOfWork.Switches.Find(it => it.Id == item.Id).FirstOrDefault();

                this._unitOfWork.Switches.Remove(deleteItem);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
