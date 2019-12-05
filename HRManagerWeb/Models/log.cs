namespace HRManagerWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("hrmanager.log")]
    public partial class log
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public log()
        {
            tasks = new HashSet<task>();
        }

        public long id { get; set; }

        public DateTime created { get; set; }

        public DateTime updated { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string user { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<task> tasks { get; set; }
    }
}
