using ECommerce.DTO;
using ECommerce.Entity;
using ECommerce.UnitOfWork;
using ECommerce.UserInterface.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UserInterface.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUoW _u;
        GeneralResponse _response;

        public UserController(IUoW u, GeneralResponse response)
        {
            _u = u;
            _response = response;
        }

        [HttpGet(Name = "ListOfUsers")]
        public IQueryable<UserList> ListOfUsers()
        {
            var uList = _u._usr.GetUserList();
            return uList;
        }

        [HttpGet("{id:int}")]
        public User Find_User(int id)
        {
            var user = _u._usr.Find(id);
            return user;
        }

        [HttpPost(Name = "Create_User")]
        public GeneralResponse Create_User(User user)
        {
            try
            {
                _u._usr.Create(user);
                _u.Commit();
                _u.Dispose();
                _response.msgSuccess = $"The user named {user.UserName} has created successfully.";
            }
            catch (Exception ex)
            {
                _response.msgError = $"User cannot be created! ({ex.Message})";
            }
            return _response;
        }

        [HttpDelete("{id:int}")]
        public User Delete_User(int id)
        {
            User user = _u._usr.Find(id);
            _u._usr.Delete(user);
            _u.Commit();
            _u.Dispose();
            return user;
        }

        [HttpPut]
        public GeneralResponse Update_User(User user)
        {
            try
            {
                _u._usr.Update(user);
                _u.Commit();
                _u.Dispose();
                _response.msgSuccess = $"The user named {user.UserName} has updated successfully.";
            }
            catch (Exception ex)
            {
                _response.msgError = $"User cannot deleted! ({ex.Message})";
            }
            return _response;
        }
    }
}
