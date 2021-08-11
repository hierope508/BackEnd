using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentsScheduler.DAL
{
    public class DALUser : BaseDAL<Model.User>
    {
        public DALUser(string connectionString) : base(connectionString)
        {
               
        }

        public override bool Exists(int id)
        {
            return User.Any(u=>u.Id == id);
        }

    }
}
