using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using PIDEV.Data;

namespace PIDEV.Domain.entities
{
    class Email
    {
        public int Id { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public DateTime OutDate { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
        // foreign key
        public int? ProducerId { get; set; } // ? nullable
        [ForeignKey("ProducerId")]
        public virtual user Producer { get; set; }

    }
}
