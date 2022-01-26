using Microsoft.AspNetCore.Mvc;

namespace QuertyKey_DAW.Controllers
{
    [ApiController]
    [Route("Keycap")]
    public class KeycapsController : BaseController
    {

        public KeycapsController(UnitOfWork.UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }



        [HttpGet]
        [Route("List")]
        public IActionResult GetListedItems()
        {
            var items = this._unitOfWork.Keycaps.GetAll();
            this._unitOfWork.Complete();
            return Ok();
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult AddItem(FrontendModels.Keycap item)
        {

            try
            {
                if (this._unitOfWork.Keycaps.Find(it => it.Name == item.Name).Any())
                {
                    return BadRequest("Keycap already registered");
                }
                var newItem = new DataModels.Keycap();
                newItem.Name = item.Name;
                newItem.Description = item.Description;
                newItem.Quantity = item.Quantity;
                newItem.Price = item.Price;
                newItem.AddedOn = DateTime.Now;

                this._unitOfWork.Keycaps.Add(newItem);

                var addedItem = this._unitOfWork.Keycaps.Find(it => it.Name == newItem.Name).FirstOrDefault();
                return Ok(addedItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("Item")]
        public IActionResult GetItem(FrontendModels.Keycap item)
        {
            try
            {
                var foundItem = this._unitOfWork.Keycaps.Find(it => it.Name == item.Name).FirstOrDefault();
                if (foundItem == null)
                {
                    return BadRequest("Cannot find the requested Keycap");
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
        public IActionResult UpdateItem(FrontendModels.Keycap item)
        {
            try
            {
                var oldItem = this._unitOfWork.Keycaps.Find(it => it.Name == it.Name).FirstOrDefault();

                oldItem.Name = item.Name;
                oldItem.Description = item.Description;
                oldItem.Quantity = item.Quantity;
                oldItem.Price = item.Price;
                oldItem.AddedOn = item.AddedOn;


                this._unitOfWork.Keycaps.Update(oldItem);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Remove")]
        public IActionResult RemoveItem(FrontendModels.Keycap item)
        {
            try
            {
                var deleteItem = this._unitOfWork.Keycaps.Find(it => it.Id == item.Id).FirstOrDefault();

                this._unitOfWork.Keycaps.Remove(deleteItem);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
