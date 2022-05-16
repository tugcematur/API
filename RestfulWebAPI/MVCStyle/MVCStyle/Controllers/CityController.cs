using Microsoft.AspNetCore.Mvc;
using MVCStyle.Data;
using MVCStyle.HttpResponses;

namespace MVCStyle.Controllers
{
    public class CityController : Controller
    {
        Context _db;
        GeneralResponse _response;
        public CityController(Context db,GeneralResponse response)
        {
            _db = db;
            _response = response;
        }
        public IActionResult List()
        {
            return Json(_db.Set<City>().ToList()); // json nesnesi yarattık, Client ta kullanıcaz, Bu blient programı ikinci bir MVC olacak    localhost:15790/City/List URL e yaz 
        }

        public IActionResult Find(int id)
        {
            return Json(_db.Set<City>().Find(id));  // localhost:15790/City/Find/1 Tek bir nesne döner


        }
        [HttpPost]
        public IActionResult Update([FromBody] City city) // Postmandeki Body bölümü , Header da özellikleri var 
        {
            try
            {
                _db.Set<City>().Update(city);
                _db.SaveChanges();
                _response.MessageSuccess = $"{city.CityName} Başarılı olarak güncellendi";
                // return Json(city); 
            }
            catch (Exception ex)
            {
                _response.MessageSuccess = $"{city.CityName} Başarılı olarak  güncellenemedi";
                _response.MessageError = $"{ex.Message} ";
               
            }


            return Json(_response);

        }

        [HttpPost]
        public IActionResult Delete([FromBody] City city) 
        {
            try
            {
                _db.Set<City>().Remove(city);
                _db.SaveChanges();
                _response.MessageSuccess = $"{city.CityName} Başarılı olarak silindi";
                // return Json(city); 
            }
            catch (Exception ex)
            {
                _response.MessageSuccess = $"{city.CityName} Başarılı olarak  silinemedi";
                _response.MessageError = $"{ex.Message} ";

            }


            return Json(_response);

        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            City city = _db.Cities.Find(id);

            try
            {
                _db.Set<City>().Remove(city);
                _db.SaveChanges();
                _response.MessageSuccess = $"{city.CityName} Başarılı olarak silindi";
             
            }
            catch (Exception ex)
            {
                _response.MessageSuccess = $"{city.CityName} Başarılı olarak  silinemedi";
                _response.MessageError = $"{ex.Message} ";

            }


            return Json(_response);

        }





        [HttpPost]
        public IActionResult Create([FromBody] City city)
        {
            try
            {
                _db.Set<City>().Add(city);
                _db.SaveChanges();
                _response.MessageSuccess = $"{city.CityName} Başarılı olarak eklendi";
                
            }
            catch (Exception ex)
            {
                _response.MessageSuccess = $"{city.CityName} Başarılı olarak eklenemedi";
                _response.MessageError = $"{ex.Message} ";

            }


            return Json(_response);

        }
    }
}
