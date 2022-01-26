using Microsoft.AspNetCore.Mvc;

namespace QuertyKey_DAW.Controllers
{
    [ApiController]
    [Route("Specialty")]
    public class SpecialtiesController : BaseController
    {

        public SpecialtiesController(UnitOfWork.UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }


        [HttpGet]
        [Route("List")]
        public IActionResult GetListedItems()
        {

            var items = this._unitOfWork.Specialty.GetAll();
            this._unitOfWork.Complete();
            return Ok();
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult AddItem(FrontendModels.Specialty item)
        {

            try
            {
                if (this._unitOfWork.Specialty.Find(it => it.Name == item.Name).Any())
                {
                    return BadRequest("Specialty item already registered");
                }
                var newItem = new DataModels.Specialty();
                newItem.Name = item.Name;
                newItem.Description = item.Description;
                newItem.Quantity = item.Quantity;
                newItem.Price = item.Price;
                newItem.AddedOn = DateTime.Now;

                this._unitOfWork.Specialty.Add(newItem);

                var addedItem  = this._unitOfWork.Specialty.Find(it => it.Name == newItem.Name).FirstOrDefault();
                return Ok(addedItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost]
        [Route("Item")]
        public IActionResult GetItem(FrontendModels.Specialty item)
        {
            try
            {
                var foundItem = this._unitOfWork.Specialty.Find(it => it.Name == item.Name).FirstOrDefault();
                if (foundItem == null)
                {
                    return BadRequest("Cannot find the requested Specialty item");
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
        public IActionResult UpdateItem(FrontendModels.Specialty item)
        {
            try
            {
                var oldItem = this._unitOfWork.Specialty.Find(it => it.Name == it.Name).FirstOrDefault();

                oldItem.Name = item.Name;
                oldItem.Description = item.Description;
                oldItem.Quantity = item.Quantity;
                oldItem.Price = item.Price;
                oldItem.AddedOn = item.AddedOn;


                this._unitOfWork.Specialty.Update(oldItem);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Remove")]
        public IActionResult RemoveItem(FrontendModels.Specialty item)
        {
            try
            {
                var deleteItem = this._unitOfWork.Specialty.Find(it => it.Id == item.Id).FirstOrDefault();

                this._unitOfWork.Specialty.Remove(deleteItem);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
