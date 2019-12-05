using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManager.domain.Entities
{
    public class Survey
    {
        public Survey()
        {
            Criteria = new List<Criterion>();
        }
        public string Title { get; set; }
        public int SurveyId { get; set; }
        [Display(Name = "Made")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public virtual List<Criterion> Criteria { get; set; }
        public int UserId { get; set; }
        public SurveyType Type { get; set; }

    }
    public enum SurveyType { Template, Submitted }
}
