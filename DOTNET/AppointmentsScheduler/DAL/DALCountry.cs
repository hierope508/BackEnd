using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentsScheduler.Model;

namespace AppointmentsScheduler.DAL
{
    public class DALCountry : BaseDAL<Country>
    {
        public DALCountry(string connectionString) : base(connectionString)
        {
            
        }

        public override bool Exists(int id)
        {
            return Country.Any(c => c.Id == id);
        }
    }
}
