using RepairShopProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepairShopProject.Business.Abstract
{
    public partial interface ICustomerService
    {
        void InsertCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);

        Customer GetById(int id);
        List<Customer> GetCustomers();
    }
}
