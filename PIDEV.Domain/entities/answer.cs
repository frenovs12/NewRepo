namespace PIDEV.Domain
{
    using PIDEV.Data;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.answer")]
    public partial class answer
    {
        public int id { get; set; }

        [Column(TypeName = "bit")]
        public bool juste { get; set; }

        [StringLength(255)]
        public string type_reponse { get; set; }

        public int? question_id { get; set; }

        public virtual question question { get; set; }
    }
}
