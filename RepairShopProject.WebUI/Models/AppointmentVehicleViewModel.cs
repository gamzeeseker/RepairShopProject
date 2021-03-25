using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RepairShopProject.WebUI.Models
{
    public partial class AppointmentVehicleViewModel
    {
        public AppointmentVehicleViewModel()
        {
            this.Vehicle = new VehicleViewModel();
        }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        public VehicleViewModel Vehicle { get; set; }
    }
}
