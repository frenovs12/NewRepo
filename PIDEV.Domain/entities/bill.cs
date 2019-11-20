using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIDEV.Data
{
    [Table("pidev.bill")]
    public partial class bill
    {
        public int id { get; set; }

        public DateTime? date { get; set; }

        [StringLength(255)]
        public string image { get; set; }

        [StringLength(255)]
        public string matricule { get; set; }

        public int somme { get; set; }

        public int? idMission { get; set; }

        public virtual mission mission { get; set; }
    }
}
