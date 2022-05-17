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

    public class CountyController : ControllerBase
    {
        IUoW _u;
        GeneralResponse _response;

        public CountyController(IUoW u, GeneralResponse response)
        {
            _u = u;
            _response = response;
        }

        [HttpGet(Name = "ListOfCounties")]
        public IQueryable<CountyList> ListOfCounties()
        {
            var cList = _u._cor.GetCountyList();
            return cList;
        }

        [HttpGet("{id:int}")]
        public GeneralResponse Find_County(int id)
        {
            var county = _u._cor.Find(id);
            if (county != null)
            {
                _response.msgSuccess = $"The county {id} numbered is exist.";
            }
            else
                _response.msgError = $"There is no a {id} numbered county.";

            return _response;
        }

        [HttpPost(Name = "Create_County")]
        public GeneralResponse Create_County(County county)
        {
            try
            {
                _u._cor.Create(county);
                _u.Commit();
                _u.Dispose();
                _response.msgSuccess = $"The county numbered {county.CountyId} has created successfully.";
            }
            catch (Exception ex)
            {
                _response.msgError = $"County cannot created because of the issue that {ex.Message}";
            }
            return _response;
        }

        [HttpDelete("{id:int}")]
        public County Delete_County(int id)
        {
            County county = _u._cor.Find(id);
            _u._cor.Delete(county);
            _u.Commit();
            _u.Dispose();
            return county;
        }

        [HttpPut]
        public GeneralResponse Update_County(County county)
        {
            try
            {
                _u._cor.Update(county);
                _u.Commit();
                _u.Dispose();
                _response.msgSuccess = $"The County numbered {county.CountyId} has updated successfully.";
            }
            catch (Exception ex)
            {
                _response.msgError = $"County cannot deleted because of the issue that {ex.Message}";
            }
            return _response;
        }
    }
}
