using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AppointmentsScheduler.Model
{
    public class Country
    {
        [Key(), JsonIgnore()]
        public int Id { get; set; }
        public string Name { get; set; }

        public int TimeZone { get; set; }
    }
}
