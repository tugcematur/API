using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entity
{
    public class InvoiceDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InvoiceDetailId { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("Id")]
        public InvoiceMain? InvoiceMain { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
    }
}
