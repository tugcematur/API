using KatmanliAPI.DTO;
using KatmanliAPI.Entity;
using KatmanliAPI.Uow;
using Microsoft.AspNetCore.Mvc;

namespace KatmanliAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OgrenciController : Controller
    {
        IUOFW _uofWork;
        public OgrenciController(IUOFW uofWork)
        {
            _uofWork = uofWork;

        }
        [HttpGet(Name = "List")]
        public List<OgrenciList> List()
        {
            return _uofWork._ogrRepos.Set().Select(x => new OgrenciList {

                Id = x.Id,
                OgrNo = x.OgrNo,
                Ad = x.Ad,
                Soyad = x.Soyad


            }).ToList();
        }

        [HttpGet("{id:int}")]

        public Ogrenci Find(int id)
        {
            return  _uofWork._ogrRepos.Find(id);
         

        }

        [HttpPost(Name ="Create")]

        public Ogrenci Create ([FromBody] Ogrenci ogrenci)
        {

           _uofWork._ogrRepos.Create(ogrenci);
            _uofWork.Commit();
            return ogrenci;
            
        }

        [HttpPut(Name ="Update")]
        public Ogrenci Update ([FromBody] Ogrenci ogrenci)
        {
            _uofWork._ogrRepos.Update(ogrenci);
            _uofWork.Commit();
            return ogrenci;

        }


        [HttpDelete(Name ="Delete")]

        public Ogrenci Delete([FromBody] Ogrenci ogrenci)
        {
            _uofWork._ogrRepos.Delete(ogrenci);
            _uofWork.Commit();
            return ogrenci;
        }

        [HttpDelete("{id:int}")]


        public Ogrenci Delete2(int id)
        {
            var ogrenci = _uofWork._ogrRepos.Find(id);
            _uofWork._ogrRepos.Delete(ogrenci);
            _uofWork.Commit();
            return ogrenci;
        }

    }
}
