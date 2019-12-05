using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HRManager.domain.Entities
{
    public enum Type { Sickness, Vacancies }
    public enum State { Pending, Accepted, Declined }
    public class DayOff
    {
        public int DayOffId { get; set; }

        [Display(Name = "Starting Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Ending Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public int Balance { get; set; }

        [Display(Name = "Duration in days")]
        public int Duration { get; set; }
        public int UserId { get; set; }

        public Type Type { get; set; }
        public State State { get; set; }



    }

}
