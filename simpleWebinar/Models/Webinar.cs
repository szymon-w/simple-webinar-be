using Foolproof;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.Models
{
    public class Webinar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdWebinar { get; set; }
        [Required]
        public string Topic { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        [GreaterThan("StartTime")]
        public DateTime EndTime { get; set; }

        [ForeignKey("User")]
        public int? IdUser { get; set; }
        public User User { get; set; }
        public ICollection<UserWebinar> UserWebinars { get; set; }

    }
}
