using Microsoft.AspNetCore.Mvc;
using RepairShopProject.Business.Abstract;
using RepairShopProject.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairShopProject.WebUI.Controllers
{
    public class VehicleController : Controller
    {
        #region Fields
        private readonly IVehicleService _vehicleService;
        private readonly ICustomerService _customerService;

        #endregion

        #region Ctor

        public VehicleController(IVehicleService vehicleService,
            ICustomerService customerService)
        {
            this._vehicleService = vehicleService;
            this._customerService = customerService;
        }
        #endregion

        #region Methods

        public ActionResult CustomerVehicles(int customerId)
        {
            var model = new VehicleCustomerViewModel();

            var customer = _customerService.GetById(customerId);
            if (customer == null)
                return View(model);

            model.CustomerId = customer.id;
            model.CustomerName = customer.fullName;

            var vehicles = _vehicleService.GetVehicles(customerId);
            model.CustomerVehicles = vehicles.Select(x =>
            {
                var vehicleModel = new VehicleViewModel
                {
                    id = x.id,
                    licensePlate = x.licensePlate,
                    brand = x.brand,
                    model = x.model,
                    modelYear = x.modelYear
                };
                return vehicleModel;
            }).ToList();

            return View(model);
        }

        #endregion
    }
}
