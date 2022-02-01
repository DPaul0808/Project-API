using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProjectApp.Models.Repos
{
    public interface IComponentRepo
    {
        Component Create(Component component);
        List<Component> Read();
        Component Read(int id);
        void Update(Component component);
        void Delete(Component component);

    }
}
