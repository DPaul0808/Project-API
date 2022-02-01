using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestProjectApp.Models
{
    public class Feature
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        [ForeignKey("Component")]
        public int? ComponentId { get; set; }
        public Component Component { get; set; }
        [ForeignKey("Game")]
        public int? GameId { get; set; }
        public Game Game { get; set; }
    }
}
