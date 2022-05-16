using System.ComponentModel.DataAnnotations;

namespace NMAPI.Data
{
    public class Vatandas
    {
        [Key]
        public string TC { get; set; } // string de olabilir 
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public DateTime DogumTarih { get; set; }
    }
}
