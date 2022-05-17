using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entity
{
    public class InvoiceMain
    {
        public InvoiceMain()
        {
            InvoiceDetails = new HashSet<InvoiceDetail>();
        }

        [Key]
        public int InvoiceMainId { get; set; }
        public int UserId { get; set; }
        public bool IsMember { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
