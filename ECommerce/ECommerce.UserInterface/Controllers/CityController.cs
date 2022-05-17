using ECommerce.DAL;
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

    public class CityController : ControllerBase
    {
        IUoW _u;
        GeneralResponse _response;

        public CityController(IUoW u, GeneralResponse response)
        {
            _u = u;
            _response = response;
        }

        [HttpGet(Name = "ListOfCities")]
        public IQueryable<CityList> ListOfCities()
        {
            var cList = _u._cir.GetCityList();
            return cList;
        }

        [HttpGet("{id:int}")]
        public GeneralResponse Find_City(int id)
        {
            var category = _u._car.Find(id);
            if (category != null)
            {
                _response.msgSuccess = $"The city {id} numbered is exist.";
            }
            else
                _response.msgError = $"There is no a {id} numbered city.";

            return _response;
        }

        [HttpPost(Name = "Create_City")]
        public GeneralResponse Create_City(City city)
        {
            try
            {
                _u._cir.Create(city);
                _u.Commit();
                _u.Dispose();
                _response.msgSuccess = $"The city numbered {city.CityId} has created successfully.";
            }
            catch (Exception ex)
            {
                _response.msgError = $"City cannot created because of the issue that {ex.Message}";
            }
            return _response;
        }

        [HttpDelete("{id:int}")]
        public City Delete_City(int id)
        {
            City city = _u._cir.Find(id);
            _u._cir.Delete(city);
            _u.Commit();
            _u.Dispose();
            return city;
        }

        [HttpPut]
        public GeneralResponse Update_City(City city)
        {
            try
            {
                _u._cir.Update(city);
                _u.Commit();
                _u.Dispose();
                _response.msgSuccess = $"The City numbered {city.CityId} has updated successfully.";
            }
            catch (Exception ex)
            {
                _response.msgError = $"City cannot deleted because of the issue that {ex.Message}";
            }
            return _response;
        }
    }
}
