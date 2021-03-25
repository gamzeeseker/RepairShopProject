using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairShopProject.WebUI.Models
{
    public partial class VehicleViewModel : BaseModel
    {
        public string licensePlate { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string modelYear { get; set; }
    }
}
