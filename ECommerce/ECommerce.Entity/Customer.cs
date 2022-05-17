using ECommerce.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entity
{
    public class Customer: IAddress
    {
        [Key]
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? Street { get; set; }
        public string? Avenue { get; set; }
        public int OutDoorNumber { get; set; }
        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public City ?City { get; set; }

        [ForeignKey("CountyId")]
        public int CountyId { get; set; }
        
    }
}
