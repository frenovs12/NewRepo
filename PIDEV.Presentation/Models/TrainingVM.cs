using PIDEV.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PIDEV.Presentation.Models
{
    public class TrainingVM
    {
        public int id { get; set; }
        [DataType(DataType.Date)]
        public DateTime? date { get; set; }
        public string description { get; set; }

        public int duration { get; set; }
        public bool isCanceled { get; set; }

        public int nbr { get; set; }
        public string room { get; set; }
        public string subject { get; set; }
        [Display(Name = "Trainer")]
        public int? trainer_id { get; set; }
        
   //     public virtual user user { get; set; }

        public virtual ICollection<user> users { get; set; }
        public IEnumerable<SelectListItem>  listUsers{ get; set; }
    }
}
