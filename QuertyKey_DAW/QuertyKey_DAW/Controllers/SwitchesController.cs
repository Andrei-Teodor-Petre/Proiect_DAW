using Microsoft.AspNetCore.Mvc;

namespace QuertyKey_DAW.Controllers
{
    [ApiController]
    [Route("Switch")]
    public class SwitchesController : BaseController
    {
        public SwitchesController(UnitOfWork.UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        [HttpGet]
        [Route("List")]
        public IActionResult GetListedItems()
        {

            var items = this._unitOfWork.Switches.GetAll();
            this._unitOfWork.Complete();
            return Ok();
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult AddItem(FrontendModels.Switch item)
        {
            try
            {
                if (this._unitOfWork.Switches.Find(swt => swt.Name == item.Name).Any())
                {
                    return BadRequest("Accesory already in registered");
                }
                var newSwt = new DataModels.Switch();
                newSwt.Name = item.Name;
                newSwt.Description = item.Description;
                newSwt.Quantity = item.Quantity;
                newSwt.Price = item.Price;
                newSwt.AddedOn = DateTime.Now;

                this._unitOfWork.Switches.Add(newSwt);

                var addedAcc = this._unitOfWork.Switches.Find(swt => swt.Name == newSwt.Name).FirstOrDefault();
                return Ok(addedAcc);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Item")]
        public IActionResult GetItem(FrontendModels.Switch item)
        {
            try
            {
                var foundItem = this._unitOfWork.Switches.Find(swt => swt.Name == item.Name).FirstOrDefault();
                if (foundItem == null)
                {
                    return BadRequest("Cannot find the requested Switch");
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
        public IActionResult UpdateItem(FrontendModels.Switch item)
        {
            try
            {
                var oldItem = this._unitOfWork.Switches.Find(swt => swt.Id == swt.Id).FirstOrDefault();

                oldItem.Name = item.Name;
                oldItem.Description = item.Description;
                oldItem.Quantity = item.Quantity;
                oldItem.Price = item.Price;
                oldItem.AddedOn = item.AddedOn;


                this._unitOfWork.Switches.Update(oldItem);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Remove")]
        public IActionResult RemoveItem(FrontendModels.Switch item)
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
