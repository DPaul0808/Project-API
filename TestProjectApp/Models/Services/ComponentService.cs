using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProjectApp.Models.Repos;
using TestProjectApp.Models.ViewModels;

namespace TestProjectApp.Models.Services
{
    public class ComponentService : IComponentService
    {
        private readonly IComponentRepo _componentRepo;
        public ComponentService(IComponentRepo componentRepo)
        {
            _componentRepo = componentRepo;
        }
        public Component Create(ComponentViewModel createComponent)
        {
            return _componentRepo.Create(new Component() { 
                Name = createComponent.Name,
                Category = createComponent.Category
            });
        }

        public List<Component> GetAll()
        {
            return _componentRepo.Read();
        }

        public Component FindById(int id)
        {
            return _componentRepo.Read(id);
        }

        public void Edit(int id, ComponentViewModel editComponent)
        {
            Component component = _componentRepo.Read(id);
            if(component != null)
            {
                component.Name = editComponent.Name;
                component.Category = editComponent.Category;
                _componentRepo.Update(component);
            }
        }

        public void Remove(int id)
        {
            Component component = _componentRepo.Read(id);
            if(component != null)
            {
                _componentRepo.Delete(component);
            }

        }
    }
}
