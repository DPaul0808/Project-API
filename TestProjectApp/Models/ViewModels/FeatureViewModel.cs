using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestProjectApp.Models.ViewModels
{
    public class FeatureViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Value { get; set; }
        public int ComponentId { get; set; }
        public int GameId { get; set; }
    }
}
