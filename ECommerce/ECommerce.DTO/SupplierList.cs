using ECommerce.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DTO
{
    public class SupplierList
    {
        public int SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public List<Product> ?ProductName { get; set; }
    }
}
