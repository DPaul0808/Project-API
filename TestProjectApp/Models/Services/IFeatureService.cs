using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProjectApp.Models.ViewModels;

namespace TestProjectApp.Models.Services
{
    public interface IFeatureService
    {
        Feature Create(FeatureViewModel createFeature);
        List<Feature> GetAll();
        Feature FindById(int id);
        void Edit(int id, FeatureViewModel editFeature);
        void Remove(int id);
    }
}
