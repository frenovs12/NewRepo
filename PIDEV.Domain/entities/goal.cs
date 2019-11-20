namespace PIDEV.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.goal")]
    public partial class goal
    {
        public int goalId { get; set; }

        [StringLength(255)]
        public string goalLevel { get; set; }

        [StringLength(255)]
        public string goalType { get; set; }

        [StringLength(255)]
        public string objectif_txt { get; set; }

        [Column(TypeName = "bit")]
        public bool state { get; set; }

        public int? evaluation_id_evaluation { get; set; }

        public virtual evaluation evaluation { get; set; }
    }
}
