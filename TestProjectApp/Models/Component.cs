using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestProjectApp.Models
{
    public class Component
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public List<Feature> Features { get; set; }
        public List<ComputerComponent> ComputersWithComponent { get; set; }

    }
    public enum Category
    {
        CPU,
        GPU,
        Memory,
        Motherboard,      
        Other
    }
}
