using System;
namespace AppointmentsScheduler.Model
{
    public class Patient : User
    {
        public string Address { get; set; }

        public string Phone { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }

        public Country Country { get; set; }

    }
}
