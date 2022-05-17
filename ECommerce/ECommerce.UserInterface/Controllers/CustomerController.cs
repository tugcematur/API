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
    public class CustomerController : ControllerBase
    {
        IUoW _u;
        GeneralResponse _response;

        public CustomerController(IUoW u, GeneralResponse response)
        {
            _u = u;
            _response = response;
        }

        [HttpGet(Name = "ListOfCustomers")]
        public IQueryable<CustomerList> ListOfCustomers()
        {
            var cList = _u._cur.GetCustomerList();
            return cList;
        }

        [HttpGet("{id:int}")]
        public GeneralResponse Find_Customer(int id)
        {
            var customer = _u._cur.Find(id);
            if (customer != null)
            {
                _response.msgSuccess = $"The customer {id} numbered is exist.";
            }
            else
                _response.msgError = $"There is no a {id} numbered customer.";

            return _response;
        }

        [HttpPost(Name = "Create_Customer")]
        public GeneralResponse Create_Customer(Customer customer)
        {
            try
            {
                _u._cur.Create(customer);
                _u.Commit();
                _u.Dispose();
                _response.msgSuccess = $"The customer numbered {customer.CustomerId} has created successfully.";
            }
            catch (Exception ex)
            {
                _response.msgError = $"Customer cannot created because of the issue that {ex.Message}";
            }
            return _response;
        }

        [HttpDelete("{id:int}")]
        public Customer Delete_Customer(int id)
        {
            Customer customer = _u._cur.Find(id);
            _u._cur.Delete(customer);
            _u.Commit();
            _u.Dispose();
            return customer;
        }

        [HttpPut]
        public GeneralResponse Update_Customer(Customer customer)
        {
            try
            {
                _u._cur.Update(customer);
                _u.Commit();
                _u.Dispose();
                _response.msgSuccess = $"The customer numbered {customer.CustomerId} has updated successfully.";
            }
            catch (Exception ex)
            {
                _response.msgError = $"Customer cannot deleted because of the issue that {ex.Message}";
            }
            return _response;
        }
    }
}
