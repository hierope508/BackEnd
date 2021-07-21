using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppointmentsScheduler.Model;

namespace AppointmentsScheduler.DAL
{
    public class BaseDAL : DbContext
    {
        protected BaseDAL(string connectionString) : base(Setup(connectionString))
        {
            
        }

        protected BaseDAL(DbContextOptions<BaseDAL> options)
            : base(options)
        {
        }

        /// <summary>
        /// Initialize DbContext to use SQL
        /// </summary>
        /// <param name="connectionString">The sql server connection string</param>
        /// <returns></returns>
        private static DbContextOptions<BaseDAL> Setup(string connectionString)
        {
            DbContextOptionsBuilder<BaseDAL> options = new DbContextOptionsBuilder<BaseDAL>();
            options.UseSqlServer(connectionString);
            return options.Options;
        }

        protected DbSet<User> User { get; set; }

        protected DbSet<Patient> Patient { get; set; }

        protected DbSet<Appointment> Appointment { get; set; }

        protected DbSet<Country> Country { get; set; }



    }
}
