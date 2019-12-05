namespace HRManagerWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("hrmanager.mission")]
    public partial class mission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mission()
        {
            reports = new HashSet<report>();
            users = new HashSet<user>();
        }

        public long id { get; set; }

        public DateTime created { get; set; }

        public DateTime updated { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateEnd { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateStart { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string location { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public long? assignee_id { get; set; }

        public int? id_skill { get; set; }

        public virtual t_skill t_skill { get; set; }

        public virtual user user { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<report> reports { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user> users { get; set; }
    }
}
