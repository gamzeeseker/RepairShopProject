using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairShopProject.WebUI.Models
{
    public partial class AppointmentViewModel : BaseModel
    {
        public AppointmentViewModel()
        {
            this.Vehicle = new VehicleViewModel();
            this.Customer = new CustomerViewModel();
        }
        public string date { get; set; }
        public VehicleViewModel Vehicle { get; set; }
        public CustomerViewModel Customer { get; set; }
    }
}
