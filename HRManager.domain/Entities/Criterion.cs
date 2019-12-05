using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManager.domain.Entities
{
    public class Criterion
    {
        public int CriterionId { get; set; }
        [Display(Name = "Question")]
        public string Description { get; set; }

        public bool? Response { get; set; }

    }
}
