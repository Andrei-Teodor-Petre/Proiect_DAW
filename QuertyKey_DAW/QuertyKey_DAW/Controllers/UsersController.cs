using Microsoft.AspNetCore.Mvc;
using frontendModel = QuertyKey_DAW.FrontendModels;
using dataModel = QuertyKey_DAW.DataModels;


namespace QuertyKey_DAW.Controllers
{
    [ApiController]
    [Route("/User")]
    public class UsersController : BaseController
    {

        public UsersController(UnitOfWork.UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        [HttpGet]
        [Route("/List")]
        public IActionResult GetListedItems()
        {
            var items = this._unitOfWork.Users.GetAll();
            this._unitOfWork.Complete();
            return Ok(items);
            
        }

        [HttpPost]
        [Route("/Add")]
        public IActionResult AddItem(frontendModel.User user)
        {
            try
            {
                if(this._unitOfWork.Users.Find(usr => usr.Username == user.Username).Any())
                {
                    return BadRequest("Username already in use");
                }
                var newUser = new dataModel.User();
                newUser.Name = user.Name;
                newUser.Role = 0;
                newUser.Username = user.Username;
                newUser.Password = user.Password;
                newUser.Address = user.Address;
                newUser.CreatedOn =DateTime.Now;
                newUser.Age = user.Age;
                newUser.Role = user.Role;

                this._unitOfWork.Users.Add(newUser);

                var addedUser = this._unitOfWork.Users.Find(user => user.Username == newUser.Username).FirstOrDefault();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("/Item")]
        public IActionResult GetItem(frontendModel.User user)
        {
            try
            {
                if (!this._unitOfWork.Users.Find(usr => usr.Username == user.Username).Any())
                {
                    return BadRequest("Cannot find the requested user");
                }

                var foundUser = this._unitOfWork.Users.Find(usr => user.Username == usr.Username).FirstOrDefault();
                return Ok(foundUser);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/Update")]
        public IActionResult UpdateItem(frontendModel.User user)
        {
            try
            {
                var oldUser = this._unitOfWork.Users.Find(usr => user.Username == usr.Username).FirstOrDefault();

                oldUser.Name = user.Name;
                oldUser.Role = user.Role;
                oldUser.Username = user.Username;
                oldUser.Password = user.Password;
                oldUser.Age = user.Age;


                this._unitOfWork.Users.Update(oldUser);

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        [Route("/Remove")]
        public IActionResult RemoveItem(frontendModel.User user)
        {
            try
            {
                var deleteItem = this._unitOfWork.Users.Find(usr => user.Username == usr.Username).FirstOrDefault();
                
                this._unitOfWork.Users.Remove(deleteItem);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
