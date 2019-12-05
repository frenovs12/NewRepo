namespace HRManagerWeb.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("hrmanager.skillsheet")]
    public partial class skillsheet
    {
        [Key]
        [Column(Order = 0, TypeName = "date")]
        public DateTime date { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idSkill { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(255)]
        public string level { get; set; }

        public virtual t_skill t_skill { get; set; }
    }
}
