using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRManagerWeb.Models
{


    [Table("hrmanager.task")]
    public partial class task
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public task()
        {
            task1 = new HashSet<task>();
            logs = new HashSet<log>();
            users = new HashSet<user>();
            users1 = new HashSet<user>();
        }

        public long id { get; set; }

        public DateTime created { get; set; }

        public DateTime updated { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public int priority { get; set; }

        public DateTime? startedAt { get; set; }

        [StringLength(255)]
        public string state { get; set; }

        public DateTime? stoppedAt { get; set; }

        [StringLength(255)]
        public string title { get; set; }

        public long? assignee_id { get; set; }

        public int? duration_id { get; set; }

        public int? estimate_id { get; set; }

        public long? parent_id { get; set; }

        public int? remaining_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<task> task1 { get; set; }

        public virtual task task2 { get; set; }

        public virtual user user { get; set; }

        public virtual tasktime tasktime { get; set; }

        public virtual tasktime tasktime1 { get; set; }

        public virtual tasktime tasktime2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<log> logs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user> users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user> users1 { get; set; }
    }
}
