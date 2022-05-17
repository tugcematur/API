using ECommerce.UnitOfWork;
using ECommerce.UserInterface.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UserInterface.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]

    public class BasketMainController : ControllerBase
    {
        IUoW _u;
        GeneralResponse _response;

        public BasketMainController(IUoW u, GeneralResponse response)
        {
            _u = u;
            _response = response;
        }
    }
}
