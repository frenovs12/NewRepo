namespace PIDEV.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.training")]
    public partial class training
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public training()
        {
            users = new HashSet<user>();
        }

        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public int duration { get; set; }

        [Column(TypeName = "bit")]
        public bool isCanceled { get; set; }

        public int nbr { get; set; }

        [StringLength(255)]
        public string room { get; set; }

        [StringLength(255)]
        public string subject { get; set; }

        public int? trainer_id { get; set; }

        public virtual user user { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user> users { get; set; }
    }
}
