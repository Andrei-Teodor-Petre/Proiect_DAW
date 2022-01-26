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
            var items = this._unitOfWork.Accesories.GetAll();
            this._unitOfWork.Complete();
            return Ok();
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult AddItem(FrontendModels.Accessory item)
        {

            try
            {
                if (this._unitOfWork.Accesories.Find(it => it.Name == item.Name).Any())
                {
                    return BadRequest("Accesory already registered");
                }
                var newItem = new DataModels.Accessory();
                newItem.Name = item.Name;
                newItem.Description = item.Description;
                newItem.Quantity = item.Quantity;
                newItem.Price = item.Price;
                newItem.AddedOn = DateTime.Now;

                this._unitOfWork.Accesories.Add(newItem);

                var addedAcc = this._unitOfWork.Accesories.Find(it => it.Name == newItem.Name).FirstOrDefault();
                return Ok(addedAcc);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("Item")]
        public IActionResult GetItem(FrontendModels.Accessory item)
        {
            try
            {
                var foundItem = this._unitOfWork.Accesories.Find(it => it.Name == item.Name).FirstOrDefault();
                if (foundItem == null)
                {
                    return BadRequest("Cannot find the requested Accessory");
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
        public IActionResult UpdateItem(FrontendModels.Accessory item)
        {
            try
            {
                var oldItem = this._unitOfWork.Accesories.Find(it => it.Name == it.Name).FirstOrDefault();

                oldItem.Name = item.Name;
                oldItem.Description = item.Description;
                oldItem.Quantity = item.Quantity;
                oldItem.Price = item.Price;
                oldItem.AddedOn = item.AddedOn;


                this._unitOfWork.Accesories.Update(oldItem);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Remove")]
        public IActionResult RemoveItem(FrontendModels.Accessory item)
        {
            try
            {
                var deleteItem = this._unitOfWork.Accesories.Find(it => it.Id == item.Id).FirstOrDefault();

                this._unitOfWork.Accesories.Remove(deleteItem);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
