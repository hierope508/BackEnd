using AppointmentsScheduler.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentsScheduler.DAL
{
    public class DALAppointment : BaseDAL<Appointment>
    {

        public DALAppointment(string connectionString) : base(connectionString) 
        {

        }

        public IList<Appointment> Select(DateTime date, string user)
        {
            return Appointment.Where(a => a.ScheduleDate == date).Include(p => p.Patient).Where(u => u.Patient.FullName.Contains(user)).ToList();
        }

        public override bool Exists(int id)
        {
            return Appointment.Any(a => a.Id == id);
        }
    }
}
