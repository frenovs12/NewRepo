using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime OutDate { get; set; }
        public string ImageUrl { get; set; }
        public string Genre { get; set; }
        // foreign key
        public int? ProducerId { get; set; } // ? nullable
        [ForeignKey("ProducerId")]
        public virtual Producer Producer { get; set; }
    }

    
    }

