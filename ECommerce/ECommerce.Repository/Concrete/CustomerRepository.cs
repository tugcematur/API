using ECommerce.Core;
using ECommerce.DAL;
using ECommerce.DTO;
using ECommerce.Entity;
using ECommerce.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Concrete
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {

        public CustomerRepository(Context db) : base(db)
        {

        }

        public IQueryable<CustomerList> GetCustomerList()
        {
            return Set().Select(x => new CustomerList
            {
                CustomerId = x.CustomerId,
                CustomerName = x.CustomerName,
                Street = x.Street,
                Avenue = x.Avenue,
                OutDoorNumber = x.OutDoorNumber,
                CityName = x.City.CityName
            });
        }
    }
}
