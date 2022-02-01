using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProjectApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int? ComputerId { get; set; }
    }
}
