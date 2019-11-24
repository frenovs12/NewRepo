namespace PIDEV.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.reclamation")]
    public partial class reclamation
    {
        public int id { get; set; }

        public DateTime? date_creation { get; set; }

        public DateTime? date_traitement { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string etat { get; set; }

        [StringLength(255)]
        public string image { get; set; }

        [StringLength(255)]
        public string objet { get; set; }

        public int? topic_id { get; set; }

        public int? user_id { get; set; }

        public virtual user user { get; set; }

        public virtual topic topic { get; set; }
    }
}
