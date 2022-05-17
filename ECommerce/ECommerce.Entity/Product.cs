using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entity
{
    public class Product
    {
        public Product()
        {
            Suppliers = new HashSet<Supplier>();
        }

        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Stock { get; set; }
        public decimal UnitPrice { get; set; }
        public int CategoryId { get; set; }
        public int UnitId { get; set; }
        public ICollection<Supplier> ?Suppliers { get; set; }

        [ForeignKey("CategoryId")]
        public Category ?Category { get; set; }

        [ForeignKey("UnitId")]
        public Unit ?Unit { get; set; }
    }
}
