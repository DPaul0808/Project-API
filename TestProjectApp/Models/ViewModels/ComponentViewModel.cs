using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestProjectApp.Models.ViewModels
{
    public class ComponentViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Category Category { get; set; }

    }
}
