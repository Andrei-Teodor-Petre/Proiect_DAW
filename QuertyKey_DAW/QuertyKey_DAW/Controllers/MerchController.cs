using Microsoft.AspNetCore.Mvc;

namespace QuertyKey_DAW.Controllers
{
    [ApiController]
    [Route("Merch")]
    public class MerchController : BaseController
    {


        public MerchController(UnitOfWork.UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        [HttpGet]
        [Route("List")]
        public IActionResult GetListedItems()
        {
            var items = this._unitOfWork.Merch.GetAll();
            this._unitOfWork.Complete();
            return Ok();
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult AddItem(FrontendModels.Merch item)
        {

            try
            {
                if (this._unitOfWork.Merch.Find(it => it.Name == item.Name).Any())
                {
                    return BadRequest("Merch item already registered");
                }
                var newItem = new DataModels.Merch();
                newItem.Name = item.Name;
                newItem.Description = item.Description;
                newItem.Quantity = item.Quantity;
                newItem.Price = item.Price;
                newItem.AddedOn = DateTime.Now;

                this._unitOfWork.Merch.Add(newItem);

                var addedAcc = this._unitOfWork.Merch.Find(it => it.Name == newItem.Name).FirstOrDefault();
                return Ok(addedAcc);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("Item")]
        public IActionResult GetItem(FrontendModels.Merch item)
        {
            try
            {
                var foundItem = this._unitOfWork.Merch.Find(it => it.Name == item.Name).FirstOrDefault();
                if (foundItem == null)
                {
                    return BadRequest("Cannot find the requested Merch Item");
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
        public IActionResult UpdateItem(FrontendModels.Merch item)
        {
            try
            {
                var oldItem = this._unitOfWork.Merch.Find(it => it.Name == it.Name).FirstOrDefault();

                oldItem.Name = item.Name;
                oldItem.Description = item.Description;
                oldItem.Quantity = item.Quantity;
                oldItem.Price = item.Price;
                oldItem.AddedOn = item.AddedOn;


                this._unitOfWork.Merch.Update(oldItem);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Remove")]
        public IActionResult RemoveItem(FrontendModels.Merch item)
        {
            try
            {
                var deleteItem = this._unitOfWork.Merch.Find(it => it.Id == item.Id).FirstOrDefault();

                this._unitOfWork.Merch.Remove(deleteItem);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
