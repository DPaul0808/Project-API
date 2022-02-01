using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProjectApp.Models.ViewModels;

namespace TestProjectApp.Models.Services
{
    public interface IComputerService
    {
        Computer Create(ComputerViewModel createComputer);
        List<Computer> GetAll();
        Computer FindById(int id);
        void Edit(int id, ComputerViewModel editComputer);
        void Remove(int id);
        List<Component> GetComputerComponents(int id);
    }
}
