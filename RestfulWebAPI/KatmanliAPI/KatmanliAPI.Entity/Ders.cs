using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliAPI.Entity
{
    public  class Ders 
    {
        public Ders()
        {
            Ogrenciler = new HashSet<Ogrenci>();
        }

        [Key]
        public int DersId { get; set; }
        public string DersAdi { get; set; }

        public ICollection<Ogrenci> Ogrenciler{ get; set; }
    }
}

//Çokaçok olacak