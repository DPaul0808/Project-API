using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProjectApp.Models.Data;

namespace TestProjectApp.Models.Repos
{
    public class ComputerDbRepo : IComputerRepo
    {
        private readonly ProjectDbContext _projectDb;
        public ComputerDbRepo(ProjectDbContext projectDb)
        {
            _projectDb = projectDb;
        }
        public Computer Create(Computer computer)
        {
            _projectDb.Computers.Add(computer);
            _projectDb.SaveChanges();

            return computer;
        }


        public List<Computer> Read()
        {
            return _projectDb.Computers.ToList();
        }
        public Computer Read(int id)
        {
            return _projectDb.Computers.Include(c => c.Components).Single(c => c.Id == id);
        }

        public void Update(Computer computer)
        {
            _projectDb.Computers.Update(computer);
            _projectDb.SaveChanges();
        }
        public void Delete(Computer computer)
        {
            _projectDb.Computers.Remove(computer);
            _projectDb.SaveChanges();
        }
    }
}
