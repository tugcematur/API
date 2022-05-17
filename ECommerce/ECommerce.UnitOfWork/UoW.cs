using ECommerce.DAL;
using ECommerce.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.UnitOfWork
{
    public class UoW: IUoW
    {
        Context _db;

        public IBasketDetailRepository _bdr { get; set; }
        public IBasketMainRepository _bmr { get; set; }
        public ICategoryRepository _car { get; private set; }
        public ICityRepository _cir { get; private set; }
        public ICountyRepository _cor { get; private set; }
        public ICustomerRepository _cur { get; private set; }
        public IInvoiceDetailRepository _idr { get; private set; }
        public IInvoiceMainRepository _imr { get; private set; }
        public IProductRepository _pr { get; private set; }
        public ISupplierRepository _sr { get; private set; }
        public IUnitRepository _unr { get; private set; }
        public IUserRepository _usr { get; private set; }

        public UoW(Context db, IBasketDetailRepository bdr,
                               IBasketMainRepository bmr,
                               ICategoryRepository car,
                               ICityRepository cir,
                               ICountyRepository cor,
                               ICustomerRepository cur,
                               IInvoiceDetailRepository idr,
                               IInvoiceMainRepository imr,
                               IProductRepository pr,
                               ISupplierRepository sr,
                               IUnitRepository unr,
                               IUserRepository usr)
        {
            _db = db;
            _bdr = bdr;
            _bmr = bmr;
            _car = car;
            _cir = cir;
            _cor = cor;
            _cur = cur;
            _idr = idr;
            _imr = imr;
            _pr = pr;
            _sr = sr;
            _unr = unr;
            _usr = usr;
        }

        public void Commit()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
