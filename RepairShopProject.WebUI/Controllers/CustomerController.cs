using Microsoft.AspNetCore.Mvc;
using RepairShopProject.Business.Abstract;
using RepairShopProject.Entities.Concrete;
using RepairShopProject.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairShopProject.WebUI.Controllers
{
    public class CustomerController : Controller
    {
        #region Fields

        private readonly ICustomerService _customerService;

        #endregion

        #region Ctor

        public CustomerController(ICustomerService customerService)   
        {
            this._customerService = customerService;
        }

        #endregion

        #region Methods

        public ActionResult Index()
        {
            var list = _customerService.GetCustomers(); 
            var model = new List<CustomerViewModel>();
            model = list.Select(x =>
            {
                return new CustomerViewModel
                {
                    id = x.id,
                    fullName = x.fullName,
                    phoneNumber = x.phoneNumber,
                    email = x.email
                };
            }).ToList();

            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var customer = _customerService.GetById(id);
            _customerService.DeleteCustomer(customer);
            return RedirectToAction("Index");
        }

        #endregion
    }
}
