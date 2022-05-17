﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DTO
{
    public class ProductList
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Stock { get; set; }
        public decimal UnitPrice { get; set; }
        public string ?CategoryName { get; set; }
        public string ?UnitName { get; set; }
        public int CategoryId { get; set; }
    }
}
