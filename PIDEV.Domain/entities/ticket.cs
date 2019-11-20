namespace PIDEV.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.ticket")]
    public partial class ticket
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public DateTime? datedebut { get; set; }

        public DateTime? datefin { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public int numberhours { get; set; }

        [StringLength(255)]
        public string place { get; set; }

        [StringLength(255)]
        public string state { get; set; }

        [StringLength(255)]
        public string typeTicket { get; set; }

        public int? project_id { get; set; }

        public int? user_id { get; set; }

        public virtual project project { get; set; }

        public virtual user user { get; set; }
    }
}
