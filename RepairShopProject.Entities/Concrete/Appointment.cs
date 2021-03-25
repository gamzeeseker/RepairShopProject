using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepairShopProject.Entities.Concrete
{
    public class Appointment:BaseEntity
    {
        public DateTime date { get; set; }
        [ForeignKey("Vehicles")]
        public int vehicleId { get; set; }
        public Vehicle Vehicles { get; set; }
    }
}
