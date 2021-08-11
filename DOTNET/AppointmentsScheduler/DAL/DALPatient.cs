using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentsScheduler.Model;

namespace AppointmentsScheduler.DAL
{
    public class DALPatient : BaseDAL<Patient>
    {

        public DALPatient(string connectionString) : base(connectionString)
        {

        }

        public override bool Exists(int id)
        {
            return Patient.Any(p => p.Id == id);
        }
    }
}
