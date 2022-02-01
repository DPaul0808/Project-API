using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestProjectApp.Models.ViewModels
{
    public class AddRemoveRoleViewModel
    {
        [Required]
        public string userId { get; set; }
        [Required]
        public string roleId { get; set; }
    }
}
