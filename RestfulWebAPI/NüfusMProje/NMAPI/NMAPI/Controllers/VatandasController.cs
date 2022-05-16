using Microsoft.AspNetCore.Mvc;
using NMAPI.Data;
using NMAPI.DTO;
using static Mernis.KPSPublicSoapClient;

namespace NMAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class VatandasController : Controller
    {
        Context _db;
        public VatandasController(Context db)
        {
            _db = db;
        }

        [HttpGet(Name = "List")]
        public List<VatandasList> List()
        {
            return _db.Set<Vatandas>().Select(x => new VatandasList {

                TC = x.TC,
                Ad = x.Ad,
                Soyad = x.Soyad,
                DogumTarih = x.DogumTarih


            }).ToList();
        }

        [HttpGet("{id:string}")]

        public Vatandas Find(string id)
        {
            return _db.Vatandas.Find(id);

        }



        //public Task<bool> TcKimlikDogrula(Vatandas vatandas)
        //{
        //    bool dogrulamaSonucu = false;
        //    try {
        //        var mernisClient = new Mernis.KPSPublicSoapClient(EndpointConfiguration.KPSPublicSoap);
        //        var tcKimlikDogrulamaServisResponse = mernisClient.TCKimlikNoDogrulaAsync(long.Parse(vatandas.TC), vatandas.Ad, vatandas.Soyad, vatandas.DogumTarih.Year).GetAwaiter().GetResult();
        //        dogrulamaSonucu = tcKimlikDogrulamaServisResponse.Body.TCKimlikNoDogrulaResult;
        //    }
        //    catch (Exception ex) {
        //        dogrulamaSonucu = false;
        //    }
        //    return Task.FromResult(dogrulamaSonucu);
        //}
       
        [HttpGet("{TcKimlik}/{Name}/{Surname}/{BirthDate}")]
        public bool TcKimlikDogrula2(string TcKimlik, string Name, string Surname, int BirthDate)
        {
            Vatandas v = _db.Vatandas.Where(x => x.TC == TcKimlik && x.Ad == Name && x.Soyad == Surname && x.DogumTarih.Year == BirthDate).FirstOrDefault();

            if (v != null) {

                return true;
            }
            else
                return false;



        }
    }
}
