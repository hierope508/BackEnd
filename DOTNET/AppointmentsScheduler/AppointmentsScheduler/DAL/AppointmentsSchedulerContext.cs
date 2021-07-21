using Microsoft.EntityFrameworkCore;
using AppointmentsScheduler.Model;

namespace AppointmentsScheduler.Data
{
    public class AppointmentsSchedulerContext : DbContext
    {
        public AppointmentsSchedulerContext (DbContextOptions<AppointmentsSchedulerContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        public DbSet<Patient> Patient { get; set; }

        public DbSet<Appointment> Appointment { get; set; }

        public DbSet<Country> Country { get; set; }

    }
}
