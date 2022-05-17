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
    public class InvoiceMainRepository: BaseRepository<InvoiceMain>, IInvoiceMainRepository
    {
        public InvoiceMainRepository(Context db): base(db)
        {
            
        }

        public IQueryable<InvoiceMainList> GetInvoiceMainList()
        {
            return Set().Select(x => new InvoiceMainList
            {
                Id = x.InvoiceMainId,
                IsMember = x.IsMember,
                UserName = x.User.UserName
            });
        }
    }
}
