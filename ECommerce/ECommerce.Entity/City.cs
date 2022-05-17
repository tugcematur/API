using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entity
{
    public class City
    {
        public City()
        {
            Counties = new HashSet<County>();
        }

        [Key]
        public int CityId { get; set; }
        public string? CityName { get; set; }
        public ICollection<County> ?Counties { get; set; }
    }
}
