using RepairShopProject.Business.Abstract;
using RepairShopProject.DataAccess.Abstract;
using RepairShopProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepairShopProject.Business.Concrete
{
    public partial class AppointmentService : IAppointmentService
    {
        private readonly IRepository<Appointment> _appointmentRepository;

        public AppointmentService(IRepository<Appointment> appointmentRepository)
        {
            this._appointmentRepository = appointmentRepository;
        }

        public List<Appointment> GetAppointments(int vehicleId = 0)
        {
            var result = new List<Appointment>();

            if (vehicleId > 0)
            {
                result = (from x in _appointmentRepository.Table
                          where x.vehicleId == vehicleId
                          select x).ToList();
            }
            else
            {
                result = (from x in _appointmentRepository.Table
                          select x).ToList();
            }
            return result;
        }

        public void InsertAppointment(Appointment appointment)
        {
            if (appointment == null)
                throw new ArgumentNullException(nameof(appointment));

            _appointmentRepository.Insert(appointment);
        }
    }
}
