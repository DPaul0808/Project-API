using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestProjectApp.Models
{
    public class Computer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ComputerComponent> Components { get; set; }
        public Computer()
        {
            Components = new List<ComputerComponent>();
        }
    }
}
