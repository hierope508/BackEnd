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
        public BaseDAL(string connectionString) : this(Setup(connectionString))
        {
            
        }

        public BaseDAL(DbContextOptions<BaseDAL> options)
            : base(options)
        {
        }

        public static DbContextOptions<BaseDAL> Setup(string connectionString)
        {
            DbContextOptionsBuilder<BaseDAL> options = new DbContextOptionsBuilder<BaseDAL>();
            options.UseSqlServer(connectionString);
            return options.Options;
        }

        public DbSet<User> User { get; set; }

        public DbSet<Patient> Patient { get; set; }

        public DbSet<Appointment> Appointment { get; set; }

        public DbSet<Country> Country { get; set; }

    }
}
