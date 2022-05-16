using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIStyle.Data
{
    public partial class Personel
    {
        [Key]
        public int PersonelId { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public virtual City ?City { get; set; } //  null!; ukaldırdık City nin soluna ? koyduk null olabilir dedik yani normalde null olamazdı 
    }
}
