using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRManager.domain.Entities

{


    [Table("hrmanager.task")]
    public partial class task
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public task()
        {
            taskCollection = new HashSet<task>();

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
        public virtual ICollection<task> taskCollection { get; set; }

        public virtual task task2 { get; set; }


    }
}
