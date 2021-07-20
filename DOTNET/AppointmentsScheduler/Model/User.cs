﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AppointmentsScheduler.Model
{
    public class User
    {
        [Key(), JsonIgnore()]
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string ? Password { get; set; } 
    }
}
