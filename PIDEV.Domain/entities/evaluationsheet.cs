namespace PIDEV.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.evaluationsheet")]
    public partial class evaluationsheet
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EvaluationId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(255)]
        public string appreciation { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(255)]
        public string comment { get; set; }

        public int? id { get; set; }

        public virtual user user { get; set; }
    }
}
