using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProjectApp.Models.ViewModels;

namespace TestProjectApp.Models.Services
{
    public interface IComponentService
    {
        Component Create(ComponentViewModel createComponent);
        List<Component> GetAll();
        Component FindById(int id);
        void Edit(int id, ComponentViewModel editComponent);
        void Remove(int id);
    }
}
