using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DTO
{
    public class CustomerList
    {
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? Street { get; set; }
        public string? Avenue { get; set; }
        public int OutDoorNumber { get; set; }
        public string ?CityName { get; set; }
    }
}
