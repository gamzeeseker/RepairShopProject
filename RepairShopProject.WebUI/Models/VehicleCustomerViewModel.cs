using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairShopProject.WebUI.Models
{
    public partial class VehicleCustomerViewModel
    {
        public VehicleCustomerViewModel()
        {
            this.CustomerVehicles = new List<VehicleViewModel>();
        }
        public List<VehicleViewModel> CustomerVehicles { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
    }
}
