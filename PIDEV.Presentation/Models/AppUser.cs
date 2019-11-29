
using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIDEV.Presentation.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Messages = new HashSet<Message>();
        }
        //1-* AppUser ||Message
        //we need to create a  virtual collection for the messages
        public virtual ICollection<Message> Messages { get; set; }

    }

}