using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppointmentsScheduler.Model;

namespace AppointmentsScheduler.DAL
{
    public class BaseContext : DbContext
    {
        protected BaseContext(string connectionString) : base(Setup(connectionString))
        {
#if DEBUG
            this.Database.EnsureCreated();
            this.Database.Migrate();
#endif
        }

        protected BaseContext(DbContextOptions<BaseContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Initialize DbContext to use SQL
        /// </summary>
        /// <param name="connectionString">The sql server connection string</param>
        /// <returns></returns>
        private static DbContextOptions<BaseContext> Setup(string connectionString)
        {
            DbContextOptionsBuilder<BaseContext> options = new DbContextOptionsBuilder<BaseContext>();
            options.UseSqlServer(connectionString);
            return options.Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            base.OnModelCreating(modelBuilder);

        }

        protected DbSet<User> User { get; set; }

        protected DbSet<Patient> Patient { get; set; }

        protected DbSet<Appointment> Appointment { get; set; }

        protected DbSet<Country> Country { get; set; }

    }
}
