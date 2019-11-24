namespace PIDEV.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.notification")]
    public partial class notification
    {
        public int id { get; set; }

        [StringLength(255)]
        public string contenu { get; set; }

        [StringLength(255)]
        public string titre { get; set; }

        public int? user_id { get; set; }

        public virtual user user { get; set; }
    }
}
