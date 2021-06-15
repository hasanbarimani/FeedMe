using FeedMe.Models.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedMe.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CooperationModel> Cooperation { get; set; }
        public DbSet<FeedBack> FeedBack { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }


    }
}
