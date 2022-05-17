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

    public class SupplierController : ControllerBase
    {
        IUoW _u;
        GeneralResponse _response;

        public SupplierController(IUoW u, GeneralResponse response)
        {
            _u = u;
            _response = response;
        }

        [HttpGet(Name = "ListOfSuppliers")]
        public IQueryable<SupplierList> ListOfSuppliers()
        {
            var sList = _u._sr.GetSupplierList();
            return sList;
        }

        [HttpGet("{id:int}")]
        public Supplier Find_Supplier(int id)
        {
            var supplier = _u._sr.Find(id);
            return supplier;
        }

        [HttpPost(Name = "Create_Supplier")]
        public GeneralResponse Create_Supplier(Supplier supplier)
        {
            try
            {
                _u._sr.Create(supplier);
                _u.Commit();
                _u.Dispose();
                _response.msgSuccess = $"The supplier numbered {supplier.SupplierId} has created successfully.";
            }
            catch (Exception ex)
            {
                _response.msgError = $"Supplier cannot be created! ({ex.Message})";
            }
            return _response;
        }

        [HttpDelete("{id:int}")]
        public Supplier Delete_Supplier(int id)
        {
            Supplier supplier = _u._sr.Find(id);
            _u._sr.Delete(supplier);
            _u.Commit();
            _u.Dispose();
            return supplier;
        }

        [HttpPut]
        public GeneralResponse Update_Supplier(Supplier supplier)
        {
            try
            {
                _u._sr.Update(supplier);
                _u.Commit();
                _u.Dispose();
                _response.msgSuccess = $"The supplier numbered {supplier.SupplierId} has updated successfully.";
            }
            catch (Exception ex)
            {
                _response.msgError = $"Supplier cannot deleted! ({ex.Message})";
            }
            return _response;
        }
    }
}
