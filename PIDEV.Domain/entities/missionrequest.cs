namespace PIDEV.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.missionrequest")]
    public partial class missionrequest
    {
        public int id { get; set; }

        public int affect { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public int? mission_id { get; set; }

        public int? user_id { get; set; }

        public virtual mission mission { get; set; }

        public virtual user user { get; set; }
    }
}
