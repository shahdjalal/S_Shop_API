using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahd_DataAccessL.Models
{
   public class ApplicationUser : IdentityUser
    {
    
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? FullName { get;  set; }

        public string? CodeResetPass { get; set; }
        public DateTime? ResetPasswordCodeExpiry { get; set; }

    }
}
