using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entity.Interfaces
{
    public interface IAddress
    {
        string Street { get; set; }
        string Avenue { get; set; }
        int OutDoorNumber { get; set; }
        int CityId { get; set; }
        int CountyId { get; set; }
    }
}
