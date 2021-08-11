using AppointmentsScheduler.Model;
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

        public override bool Exists(int id)
        {
            return Appointment.Any(a => a.Id == id);
        }
    }
}
