using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entity
{
    public class Unit
    {
        public Unit()
        {
            Products = new HashSet<Product>();
        }
        [Key]
        public int UnitId { get; set; }
        public string? UnitName { get; set; }
        public ICollection<Product> ?Products { get; set; }
    }
}
