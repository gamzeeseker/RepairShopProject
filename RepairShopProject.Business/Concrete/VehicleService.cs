using RepairShopProject.Business.Abstract;
using RepairShopProject.DataAccess.Abstract;
using RepairShopProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepairShopProject.Business.Concrete
{
    public partial class VehicleService : IVehicleService
    {
        #region Fields
        private readonly IRepository<Vehicle> _vehicleRepository;
        #endregion

        #region Ctor

        public VehicleService(IRepository<Vehicle> vehicleRepository)
        {
            this._vehicleRepository = vehicleRepository;
        }

        public Vehicle GetById(int id)
        {
            if (id <= 0)
                return null;

            return _vehicleRepository.GetById(id);
        }

        #endregion

        #region Methods

        public List<Vehicle> GetVehicles(int customerId = 0)
        {
            var result = new List<Vehicle>();

            if (customerId > 0)
            {
                
                result = (from x in _vehicleRepository.Table
                          where x.customerId == customerId
                          select x).ToList();
            }
            else
            {
                result = (from x in _vehicleRepository.Table
                          select x).ToList();
            }
            return result;

        }

        #endregion
    }
}
