using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TestProjectApp.Models.Data
{
    public class ProjectDbContext : IdentityDbContext<ApplicationUser>
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ComputerComponent>().HasKey(k => new { k.ComputerId, k.ComponentId });
            modelBuilder.Entity<ComputerComponent>()
                .HasOne(pc => pc.Computer)
                .WithMany(c => c.Components)
                .HasForeignKey(pc => pc.ComputerId);
            modelBuilder.Entity<ComputerComponent>()
                .HasOne(cp => cp.Component)
                .WithMany(pc => pc.ComputersWithComponent)
                .HasForeignKey(cp => cp.ComponentId);      
        }

        public DbSet<Computer> Computers { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}
