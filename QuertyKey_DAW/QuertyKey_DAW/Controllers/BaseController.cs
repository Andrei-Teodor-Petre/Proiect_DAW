using Microsoft.AspNetCore.Mvc;

using QuertyKey_DAW.UnitOfWork;

namespace QuertyKey_DAW.Controllers
{
    public class BaseController : Controller
    {

        protected readonly UnitOfWork.UnitOfWork _unitOfWork;

        public BaseController(UnitOfWork.UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
