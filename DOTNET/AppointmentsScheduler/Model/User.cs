using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AppointmentsScheduler.Model
{
    public class User
    {
        [Key()]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [JsonIgnore]
        public string ? Password { get; set; } 

        public bool ? IsActive { get; set; }

    }
}
