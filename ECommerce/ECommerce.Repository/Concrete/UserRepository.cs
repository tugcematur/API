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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(Context db) : base(db)
        {
            
        }

        public IQueryable<UserList> GetUserList()
        {
            return Set().Select(x => new UserList
            {
                UserName = x.UserName,
                Password = x.Password,
                Role = x.Role
            });
        }
    }
}
