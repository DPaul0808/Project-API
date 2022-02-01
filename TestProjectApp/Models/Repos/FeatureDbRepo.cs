using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProjectApp.Models.Data;

namespace TestProjectApp.Models.Repos
{
    public class FeatureDbRepo : IFeatureRepo
    {
        private readonly ProjectDbContext _projectDb;
        public FeatureDbRepo(ProjectDbContext projectDb)
        {
            _projectDb = projectDb;
        }
        public Feature Create(Feature feature)
        {
            _projectDb.Features.Add(feature);
            _projectDb.SaveChanges();

            return feature;
        }


        public List<Feature> Read()
        {
            return _projectDb.Features.ToList();
        }

        public Feature Read(int id)
        {
            return _projectDb.Features.SingleOrDefault(f => f.Id == id);
        }

        public void Update(Feature feature)
        {
            _projectDb.Features.Update(feature);
            _projectDb.SaveChanges();
        }
        public void Delete(Feature feature)
        {
            _projectDb.Features.Remove(feature);
            _projectDb.SaveChanges();
        }
    }
}
