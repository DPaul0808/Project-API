using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestProjectApp.Models.ViewModels
{
    public class ComputerViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int CpuId { get; set; }
        [Required]
        public int GpuId { get; set; }
        [Required]
        public int MemoryId { get; set; }
        [Required]
        public int MotherboardId { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}
