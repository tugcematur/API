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
    public class InvoiceDetailController : ControllerBase
    {
        IUoW _u;
        GeneralResponse _response;

        public InvoiceDetailController(IUoW u, GeneralResponse response)
        {
            _u = u;
            _response = response;
        }

        [HttpGet("{id:int}")]
        public InvoiceDetail Find_InvoiceDetail(int id)
        {
            var detail = _u._idr.Find(id);
            return detail;
        }

        [HttpGet(Name = "ListOfInvoiceDetail")]
        public IQueryable<InvoiceDetailList> ListOfInvoiceDetail()
        {
            var iList = _u._idr.GetInvoiceDetailList();
            return iList;
        }
    }
}
