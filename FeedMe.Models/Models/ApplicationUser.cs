using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FeedMe.Models.Models
{
   public class ApplicationUser:IdentityUser
    {

        public bool AdminRole{ get;set; }
        public bool ManagerRole { get; set; }
    }
}
