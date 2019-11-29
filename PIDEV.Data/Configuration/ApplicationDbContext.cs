using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.ModelConfiguration;

using System.Data.Entity;


namespace PIDEV.Presentation.Controllers
{
    public class ApplicationDbContext : IdentityDbContext
    {
        
      public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {  
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Message>()
                .HasOne<AppUser>(a => a.AppUser)
                .WithMany(d => d.Messages)
                .HasForeignKey(d => d.UserId);

        }

    }
}