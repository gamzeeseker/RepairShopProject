using Microsoft.AspNetCore.Mvc;
using RepairShopProject.Business.Abstract;
using RepairShopProject.Entities.Concrete;
using RepairShopProject.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace RepairShopProject.WebUI.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly IAppointmentService _appointmentService;
        private readonly ICustomerService _customerService;

        public AppointmentController(IVehicleService vehicleService,
            IAppointmentService appointmentService,
            ICustomerService customerService)
        {
            this._vehicleService = vehicleService;
            this._appointmentService = appointmentService;
            this._customerService = customerService;
        }

        public ActionResult CreateAppointment(int vehicleId)
        {
            var vehicle = _vehicleService.GetById(vehicleId);
            if (vehicle == null)
                return RedirectToAction("Index", "Home");

            var model = new AppointmentVehicleViewModel();

            //model.Vehicle.Brand = vehicle.Brand;    

            model.Vehicle = new VehicleViewModel
            {
                id = vehicle.id,
                licensePlate = vehicle.licensePlate,
                brand = vehicle.brand,
                model = vehicle.model,
                modelYear = vehicle.modelYear
            };
            model.Date = DateTime.Now.AddDays(1);

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateAppointment(AppointmentVehicleViewModel model)
        {
            var appointment = new Appointment();
            appointment.date = model.Date;
            appointment.vehicleId = model.Vehicle.id;
            _appointmentService.InsertAppointment(appointment);
            
            return RedirectToAction("Appointments", "Appointment");
        }

        public ActionResult Appointments()
        {
            var appointments = _appointmentService.GetAppointments();
            var model = new List<AppointmentViewModel>();

            model = appointments.Select(x =>
            {
                var appointment = new AppointmentViewModel
                {
                    id = x.id,
                    date = x.date.ToString("dd:MM:yyyy HH:mm")
                };
                var vehicle = _vehicleService.GetById(x.vehicleId);
                if (vehicle != null)
                {
                    appointment.Vehicle = new VehicleViewModel
                    {
                        licensePlate = vehicle.licensePlate,
                        brand = vehicle.brand,
                        model = vehicle.model,
                        modelYear = vehicle.modelYear
                    };
                    var customer = _customerService.GetById(vehicle.id);
                    if (customer != null)
                    {
                        appointment.Customer = new CustomerViewModel
                        {
                            fullName = customer.fullName,
                            phoneNumber = customer.phoneNumber
                        };
                    }
                }
                return appointment;

            }).ToList();

            return View(model);
        }
    }
}
