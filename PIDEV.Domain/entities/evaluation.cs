namespace PIDEV.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.evaluation")]
    public partial class evaluation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public evaluation()
        {
            goals = new HashSet<goal>();
            users = new HashSet<user>();
        }

        [Key]
        public int id_evaluation { get; set; }

        [Column(TypeName = "bit")]
        public bool? activate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? enddate { get; set; }

        [StringLength(255)]
        public string evalname { get; set; }

        [StringLength(255)]
        public string evaltype { get; set; }

        public int id_engineer { get; set; }

        public int id_manager { get; set; }

        [Column(TypeName = "date")]
        public DateTime? startdate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<goal> goals { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user> users { get; set; }
    }
}
