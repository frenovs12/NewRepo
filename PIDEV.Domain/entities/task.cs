namespace PIDEV.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.task")]
    public partial class task
    {
        public int id { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public DateTime? endDate { get; set; }

        public DateTime? startDate { get; set; }

        [StringLength(255)]
        public string title { get; set; }

        public int? project_id { get; set; }

        public int? user_id { get; set; }

        public virtual project project { get; set; }

        public virtual user user { get; set; }
    }
}
