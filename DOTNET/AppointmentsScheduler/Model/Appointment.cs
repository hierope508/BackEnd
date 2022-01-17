using System;
using System.ComponentModel.DataAnnotations;

namespace AppointmentsScheduler.Model
{
    public class Appointment
    {
        [Key()]
        public int Id { get; set; }
        
        public virtual Patient Patient { get; set; }

        public DateTime ScheduleDate { get; set; }

        public string Status { get; set; }

    }
}
