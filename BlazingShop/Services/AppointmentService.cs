using BlazingShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingShop.Services
{
    
    public class AppointmentService
    {
        private readonly ApplicationDbContext _db;
        public AppointmentService(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateAppointment(Appointment appointment)
        {
            _db.Appointments.Add(appointment);
            _db.SaveChanges();
            return true;
        }
    }
}
