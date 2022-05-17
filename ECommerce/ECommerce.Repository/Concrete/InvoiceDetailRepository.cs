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
    public class InvoiceDetailRepository: BaseRepository<InvoiceDetail>, IInvoiceDetailRepository
    {
        public InvoiceDetailRepository(Context db): base(db)
        {
            
        }

        public IQueryable<InvoiceDetailList> GetInvoiceDetailList()
        {
            return Set().Select(x => new InvoiceDetailList
            {
                InvoiceDetailId = x.InvoiceDetailId,
                ProductName = x.Product.ProductName
            });
        }
    }
}
