using RepairShopProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepairShopProject.Business.Abstract
{
    public partial interface IVehicleService
    {
        List<Vehicle> GetVehicles(int customerId = 0);
        Vehicle GetById(int id);
    }
}
