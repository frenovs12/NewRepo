namespace HRManagerWeb.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("hrmanager.fiche_evaluation")]
    public partial class fiche_evaluation
    {
        [Key]
        public int F_ID { get; set; }

        public int? ad { get; set; }

        public int? ang { get; set; }

        public int? aut { get; set; }

        public int? capa { get; set; }

        public int? capn { get; set; }

        public int? cet { get; set; }

        public int? cli { get; set; }

        public int? com { get; set; }

        public int? comma { get; set; }

        public int? cri { get; set; }

        public int? fran { get; set; }

        public int? gp { get; set; }

        public int? ic { get; set; }

        public int? lead { get; set; }

        public int? mdq { get; set; }

        public int? rs { get; set; }

        public int? te { get; set; }
    }
}
