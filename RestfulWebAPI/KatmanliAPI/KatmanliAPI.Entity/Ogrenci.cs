using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliAPI.Entity
{
    public  class Ogrenci
    {
        public Ogrenci()
        {
            Dersler = new HashSet<Ders>();
        }
        [Key]
        public int Id { get; set; }
        public string OgrNo { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
      

        public ICollection<Ders> Dersler { get; set; }
    }
}
