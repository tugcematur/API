using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIStyle.Data
{
    public partial class City
    {
        public City()
        {
            Personels = new HashSet<Personel>();
        }
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; } = null!;
        public string? Picture { get; set; }

        public virtual ICollection<Personel> Personels { get; set; }
    }
}
