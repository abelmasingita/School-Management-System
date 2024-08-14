using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    [Table("Event")]
    public class Event
    {
        [Key]
        public int id { get; set; }

        [DisplayName("Event Name")]
        public string title { get; set; }

        [DisplayName("Event Start")]
        public DateTime start { get; set; }

        [DisplayName("Event End")]
        public DateTime end { get; set; }

        [DisplayName("All Day")]
        public bool allDay { get; set; }
    }
}
