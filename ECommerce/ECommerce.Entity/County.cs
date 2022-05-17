using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entity
{
    public class County
    {
        public County()
        {
            Customers = new HashSet<Customer>();
        }

        [Key]
        public int CountyId { get; set; }
        public string? CountyName { get; set; }
        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public City ?City { get; set; }
        public ICollection<Customer> ?Customers { get; set; }
    }
}
