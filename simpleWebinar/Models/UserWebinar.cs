using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.Models
{
    public class UserWebinar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUserWebinar { get; set; }
        public NoteName? Note { get; set; }

        public enum NoteName { 
            Terrible = 1, 
            NotGood = 2, 
            NothingSpecial = 3, 
            Good = 4, 
            Fantastic = 5
        }

        [ForeignKey("User")]
        public int IdUser { get; set; }
        public User User { get; set; }

        [ForeignKey("Webinar")]
        public int IdWebinar { get; set; }
        public Webinar Webinar { get; set; }

    }
}
