using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentsScheduler.Model
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        public string  FullName { get; set; }
        public string Address { get; set; }

        public string Phone { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }

        public Country Country { get; set; }

    }
}
