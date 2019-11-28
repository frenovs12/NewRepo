namespace PIDEV.Domain
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("pidev.competence")]
    public partial class competence
    {
        public int id { get; set; }

        [StringLength(255)]
        public string description_c { get; set; }

        [StringLength(255)]
        public string Famille { get; set; }

        [StringLength(255)]
        public string metier { get; set; }

        public int? niveau { get; set; }

        [StringLength(255)]
        public string nom_c { get; set; }
    }
}
