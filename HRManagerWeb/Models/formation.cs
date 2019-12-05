namespace HRManagerWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("hrmanager.formation")]
    public partial class formation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public formation()
        {
            users = new HashSet<user>();
        }

        public long id { get; set; }

        [StringLength(255)]
        public string Salle { get; set; }

        [StringLength(255)]
        public string Skillz { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public DateTime? ends { get; set; }

        public int nbr_place { get; set; }

        public int place_max { get; set; }

        public DateTime? starts { get; set; }

        [StringLength(255)]
        public string title { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user> users { get; set; }
    }
}
