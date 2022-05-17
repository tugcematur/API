using ECommerce.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.UnitOfWork
{
    public interface IUoW
    {
        IBasketDetailRepository _bdr { get; }
        IBasketMainRepository _bmr { get; }
        ICategoryRepository _car { get; }
        ICityRepository _cir { get; }
        ICountyRepository _cor { get; }
        ICustomerRepository _cur { get; }
        IInvoiceDetailRepository _idr { get; }
        IInvoiceMainRepository _imr { get; }
        IProductRepository _pr { get; }
        ISupplierRepository _sr { get; }
        IUnitRepository _unr { get; }
        IUserRepository _usr { get; }

        void Commit();
        void Dispose();
    }
}
