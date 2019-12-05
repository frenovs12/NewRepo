namespace HRManagerWeb.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("hrmanager.report")]
    public partial class report
    {
        public long id { get; set; }

        public DateTime created { get; set; }

        public DateTime updated { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public int? nature { get; set; }

        public long price { get; set; }

        public int? state { get; set; }

        public long? id_mission { get; set; }

        public virtual mission mission { get; set; }
    }
}
