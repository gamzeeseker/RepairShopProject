using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairShopProject.WebUI.Models
{
    public class CustomerViewModel : BaseModel
    {
        public string fullName { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public bool IsRemoved { get; set; }

    }
}
