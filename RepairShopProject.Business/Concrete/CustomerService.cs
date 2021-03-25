using RepairShopProject.Business.Abstract;
using RepairShopProject.DataAccess.Abstract;
using RepairShopProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepairShopProject.Business.Concrete
{
    public partial class CustomerService : ICustomerService
    {
        #region Fields

        private readonly IRepository<Customer> _customerRepository;

        #endregion

        #region Ctor

        public CustomerService(IRepository<Customer> customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        #endregion

        #region Methods

        public void DeleteCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            customer.IsRemoved = true;
            _customerRepository.SaveChanges();
        }

        public Customer GetById(int id)
        {
            if (id <= 0)
                return null;

            return _customerRepository.GetById(id);
        }

        public List<Customer> GetCustomers()
        {
            var query = (from x in _customerRepository.Table
                         select x).ToList();
            return query;
        }

        public void InsertCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            _customerRepository.Insert(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            _customerRepository.Update(customer);
        }

        #endregion
    }
}
