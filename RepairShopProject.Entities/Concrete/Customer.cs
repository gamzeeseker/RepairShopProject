using RepairShopProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepairShopProject.Entities.Concrete
{
    public class Customer : BaseEntity, IRemovable
    {
        public string fullName { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
        public bool IsRemoved { get; set; }
    }
}
