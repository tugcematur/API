using ECommerce.DAL;
using ECommerce.DTO;
using ECommerce.Entity;
using ECommerce.UnitOfWork;
using ECommerce.UserInterface.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UserInterface.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class InvoiceMainController : ControllerBase
    {
        IUoW _u;
        GeneralResponse _response;

        public InvoiceMainController(IUoW u, GeneralResponse response)
        {
            _u = u;
            _response = response;
        }

        [HttpGet(Name = "ListOfInvoiceMain")]
        public IQueryable<InvoiceMainList> ListOfInvoiceMain()
        {
            var iList = _u._imr.GetInvoiceMainList();
            return iList;
        }

        [HttpPost("{id:int}")]
        public GeneralResponse Create_InvoiceMain([FromServices] GeneralResponse _response, int id)
        {
            InvoiceMain main = new InvoiceMain();
            try
            {
                var user = _u._usr.Find(id);
                if (user != null)
                {
                    main.IsMember = true;
                    main.UserId = id;
                }
                else
                {
                    main.IsMember = false;
                }
                main.User = user;
                _u._imr.Create(main);
                _u.Commit();
                _response.msgSuccess = "Invoice has created successfully.";
            }
            catch (Exception ex)
            {
                _response.msgError = $"Invoice cannot be created! ({ex.Message})";
            }
            return _response;
        }
    }
}
