using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProjectApp.Models.Data;

namespace TestProjectApp.Models.Repos
{
    public class ComponentDbRepo : IComponentRepo
    {
        private readonly ProjectDbContext _projectDb;
        public ComponentDbRepo(ProjectDbContext projectDb)
        {
            _projectDb = projectDb;
        }
        public Component Create(Component component)
        {
            _projectDb.Components.Add(component);
            _projectDb.SaveChanges();

            return component;
        }

        public List<Component> Read()
        {
            return _projectDb.Components.ToList();
        }

        public Component Read(int id)
        {
            return _projectDb.Components.Include(c => c.Features).Single(c => c.Id == id);
        }


        public void Update(Component component)
        {
            _projectDb.Components.Update(component);
            _projectDb.SaveChanges();
        }
        public void Delete(Component component)
        {
            _projectDb.Components.Remove(component);
            _projectDb.SaveChanges();
        }
    }
}
