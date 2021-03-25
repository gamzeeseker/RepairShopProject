using RepairShopProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepairShopProject.Business.Abstract
{
    public partial interface IAppointmentService
    {
        void InsertAppointment(Appointment appointment);

        List<Appointment> GetAppointments(int vehicleId = 0);
    }
}
