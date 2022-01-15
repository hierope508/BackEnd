using AppointmentsScheduler.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentsScheduler.DAL
{
    public class DALUser : BaseDAL<User>
    {
        public DALUser(string connectionString) : base(connectionString)
        {
               
        }

        public override bool Exists(int id)
        {
            return User.Any(u=>u.Id == id);
        }

        public User Select(string login)
        {
            return User.Where(u => u.Email == login && u.IsActive == true).FirstOrDefault();
        }

    }
}
