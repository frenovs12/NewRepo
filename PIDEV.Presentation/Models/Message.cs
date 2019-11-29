using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PIDEV.Presentation.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        public String UserName { get; set; }
        [Required]
        public String Text { get; set; }
        public DateTime When { get; set; }
        public int UserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}