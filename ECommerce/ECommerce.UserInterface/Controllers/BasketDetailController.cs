using ECommerce.UnitOfWork;
using ECommerce.UserInterface.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UserInterface.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]

    public class BasketDetailController : ControllerBase
    {
        IUoW _u;
        GeneralResponse _respose;

        public BasketDetailController(IUoW u, GeneralResponse response)
        {
            _u = u;
            _respose = response;
        }
    }
}
