using APIStyle.Data;
using APIStyle.DTO;
using APIStyle.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIStyle.Controllers
{
    [Route("[controller]/[action]")] // başına api geldi , çalıştırırken api getiricez başına 
    [ApiController]
    public class PersonelController : ControllerBase
    {
        myContext _db;
        GeneralResponse _response;
        public PersonelController(myContext db,GeneralResponse response)
        {
            _db = db;
            _response = response;
        }

        [HttpGet(Name = "List")] // SAdece Get kullanıcağımız için direkt [HttpGet ] yazabiliriz , ilk Geti çalıştırır.
        public List<PersonelList> List() // Geridönüş tipini değiştirdik string ti
        {
            //return "Şamil";

            return _db.Personels.Select(x=> new PersonelList {
            
            PersonelId= x.PersonelId,
            Name= x.Name,
            Surname = x.Surname,
            CityId = x.CityId,
            CityName = x.City.CityName

            
            }).ToList();
        }

        [HttpGet]





        [HttpPost(Name = "Create")]
        public GeneralResponse Create([FromBody] Personel personel) // Geridönüş tipini değiştirdik string ti
        {
            try
            {
                _db.Personels.Add(personel);
                _db.SaveChanges();
                _response.successMessage = $"{personel.Name} kaydı başarılı";
            }
            catch (Exception ex)
            {
                _response.successMessage = $"{personel.Name} kaydı başarısız";
                _response.errorMessage = $"{ex.Message}";

            }

            return _response;
        }



        [HttpPut(Name = "Update")] // [HttpPost(Name = "Update")]  olarak da yazılabilir
        public GeneralResponse Update([FromBody] Personel personel) 
        {
            try
            {
                _db.Personels.Update(personel);
                _db.SaveChanges();
                _response.successMessage = $"{personel.Name} güncelleme başarılı";
            }
            catch (Exception ex)
            {
                _response.successMessage = $"{personel.Name} güncelleme başarısız";
                _response.errorMessage = $"{ex.Message}";

            }

            return _response;
        }


        [HttpDelete(Name = "Delete")] // [HttpPost(Name = "Update")]  olarak da yazılabilir
        public GeneralResponse Delete([FromBody] Personel personel)
        {
            //Personel personel = _db.Set<Personel>().Find(id);
            try
            {
                _db.Personels.Remove(personel);
                _db.SaveChanges();
                _response.successMessage = $"{personel.Name} silme başarılı";
            }
            catch (Exception ex)
            {
                _response.successMessage = $"{personel.Name} silme başarısız";
                _response.errorMessage = $"{ex.Message}";

            }

            return _response;
        }

        [HttpGet("{id:int}")]
        public Personel Find(int id)
        {
            return _db.Set<Personel>().Find(id);
           
        }

        [HttpDelete("{id:int}")]
        public Personel Delete(int id)
        {
            var personel = _db.Set<Personel>().Find(id);

                _db.Personels.Remove(personel);
                _db.SaveChanges();
                
         
            return personel;
        }
    }
}


//api controller olduğu için Şamill i otomatik olarak json a çevirecek  string e değil

//[HttpGet(Name = "Forecast2")]  olarak name verirse en baştaki apiyi kaldırabiliriz  [Route("api/[controller]/[action]")]