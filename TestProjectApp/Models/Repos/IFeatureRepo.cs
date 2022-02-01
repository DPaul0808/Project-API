using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProjectApp.Models.Repos
{
    public interface IFeatureRepo
    {
        Feature Create(Feature feature);
        List<Feature> Read();
        Feature Read(int id);
        void Update(Feature feature);
        void Delete(Feature feature);
    }
}
