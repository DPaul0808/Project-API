using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProjectApp.Models
{
    public class ComputerComponent
    {
        public int ComputerId { get; set; }
        public Computer Computer { get; set; }
        public int ComponentId { get; set; }
        public Component Component { get; set; }
    }
}
