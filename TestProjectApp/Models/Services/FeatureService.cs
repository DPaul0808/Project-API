using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProjectApp.Models.Repos;
using TestProjectApp.Models.ViewModels;

namespace TestProjectApp.Models.Services
{
    public class FeatureService : IFeatureService
    {
        private readonly IFeatureRepo _featureRepo;
        public FeatureService(IFeatureRepo featureRepo)
        {
            _featureRepo = featureRepo;
        }
        public Feature Create(FeatureViewModel createFeature)
        {
            Feature feature = new Feature()
            {
                Name = createFeature.Name,
                Value = createFeature.Value
            };
            if (createFeature.ComponentId == 0)
            {
                feature.GameId = createFeature.GameId;
            }
            else if (createFeature.GameId == 0)
            {
                feature.ComponentId = createFeature.ComponentId;
            }

            feature = _featureRepo.Create(feature);

            return feature;
        }

        public List<Feature> GetAll()
        {
            return _featureRepo.Read();
        }

        public Feature FindById(int id)
        {
            return _featureRepo.Read(id);
        }

        public void Edit(int id, FeatureViewModel editFeature)
        {
            Feature feature = _featureRepo.Read(id);
            if (feature != null)
            {
                feature.Name = editFeature.Name;
                feature.Value = editFeature.Value;

                _featureRepo.Update(feature);
            }
        }

        public void Remove(int id)
        {
            Feature feature = _featureRepo.Read(id);
            if (feature != null)
            {
                _featureRepo.Delete(feature);
            }
        }
    }
}
