using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepairShopProject.Entities.Concrete
{
    public class Vehicle : BaseEntity
    {
        public string licensePlate { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string modelYear { get; set; }

        [ForeignKey("Customer")]
        public int customerId { get; set; }
        public Customer Customers { get; set; }
    }
}
