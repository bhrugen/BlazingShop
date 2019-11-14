using BlazingShop.Data;
using Microsoft.EntityFrameworkCore;
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
            appointment.ProductId = appointment.Product.Id;
            appointment.Product = null;
            _db.Appointments.Add(appointment);
            _db.SaveChanges();
            return true;
        }
        public List<Appointment> GetAppointments()
        {
            return _db.Appointments.Include(u => u.Product).Include(u => u.Product.Category).ToList();
        }


        public bool ConfirmAppointment(Appointment objAppointment)
        {
            var ExistingAppointment = _db.Appointments.FirstOrDefault(x => x.Id == objAppointment.Id);
            if (ExistingAppointment != null)
            {
                ExistingAppointment.IsConfirmed = true;
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool DeleteAppointment(Appointment objAppointment)
        {
            var ExistingAppointment = _db.Appointments.FirstOrDefault(x => x.Id == objAppointment.Id);
            if (ExistingAppointment != null)
            {
                _db.Appointments.Remove(ExistingAppointment);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}