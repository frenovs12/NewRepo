namespace PIDEV.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.topic")]
    public partial class topic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public topic()
        {
            questions = new HashSet<question>();
            reclamations = new HashSet<reclamation>();
            results = new HashSet<result>();
        }

        public int id { get; set; }

        public int dureeTopic { get; set; }

        [StringLength(255)]
        public string image { get; set; }

        [StringLength(255)]
        public string nom { get; set; }

        public int nombre_question { get; set; }

        public int? domain_id { get; set; }

        public virtual domain domain { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<question> questions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reclamation> reclamations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<result> results { get; set; }
    }
}
