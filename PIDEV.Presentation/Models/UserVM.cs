using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIDEV.Presentation.Models
{
    public class UserVM
    {
        public int id { get; set; }
        public int age { get; set; }
        public DateTime? birthDate { get; set; }
        public DateTime? datenaissance { get; set; }
        public DateTime? daterecrue { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public string tel { get; set; }
    }
}