using Microsoft.AspNetCore.Mvc;
using MVCStyle.Data;
using MVCStyle.HttpResponses;

namespace MVCStyle.Controllers
{
    public class PersonelController : Controller
    {
        Context _db;
        GeneralResponse _response;
        public PersonelController(Context db, GeneralResponse response)
        {
            _db = db;
            _response = response;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Json(_db.Set<Personel>().ToList());
        }

        [HttpGet]

        public IActionResult Find(int id)
        {
            return Json(_db.Set<Personel>().Find(id));

        }

        [HttpPost]

        public IActionResult Update([FromBody] Personel personel)
        {
            try
            {
                _db.Set<Personel>().Update(personel);
                _db.SaveChanges();
                _response.MessageSuccess = $"PersonelId si {personel.PersonelId} olan personel Başarılı olarak güncellendi";
            }
            catch (Exception ex)
            {

                _response.MessageSuccess = $"PersonelId si {personel.PersonelId} olan personel Başarılı olarak  güncellenemedi";
                _response.MessageError = $"{ex.Message} ";
            }

            return Json(_response);
        }

        [HttpPost]

        public IActionResult Create([FromBody] Personel personel)
        {
            try
            {
                _db.Personels.Add(personel);
                _db.SaveChanges();
                _response.MessageSuccess =  $"PersonelId si {personel.PersonelId} olan personel Başarılı olarak eklendi";
            }
            catch (Exception ex)
            {

                _response.MessageSuccess = $"PersonelId si {personel.PersonelId} olan personel Başarılı olarak  eklenemedi";
                _response.MessageError = $"{ex.Message} ";
            }

            return Json(_response);
        }


        [HttpPost]

        public IActionResult Delete([FromBody] Personel personel)
        {
            try
            {
                _db.Set<Personel>().Remove(personel);
                _db.SaveChanges();
                _response.MessageSuccess = $"PersonelId si {personel.PersonelId} olan personel Başarılı olarak silindi";
            }
            catch (Exception  ex)
            {

               _response.MessageSuccess = $"PersonelId si {personel.PersonelId} olan personel Başarılı olarak  silinemedi";
                _response.MessageError = $"{ex.Message}";
            }


            return Json(_response);
        }

        [HttpGet]

        public IActionResult Delete(int id)
        {
            Personel personel = _db.Personels.Find(id);

            try
            {
                _db.Set<Personel>().Remove(personel);
                _db.SaveChanges();
                _response.MessageSuccess = $"PersonelId si {personel.PersonelId} olan personel Başarılı olarak silindi ";


            }
            catch (Exception ex)
            {
                _response.MessageSuccess = $"PersonelId si {personel.PersonelId} olan personel Başarılı olarak  silinemedi";
                _response.MessageError = $"{ex.Message}";
            }

            return Json(_response);
        }
    }
}
