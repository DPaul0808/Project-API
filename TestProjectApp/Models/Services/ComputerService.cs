using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProjectApp.Models.Repos;
using TestProjectApp.Models.ViewModels;

namespace TestProjectApp.Models.Services
{
    public class ComputerService : IComputerService
    {
        private readonly IComputerRepo _computerRepo;
        private readonly IComponentRepo _componentRepo;
        public ComputerService(IComputerRepo computerRepo, IComponentRepo componentRepo)
        {
            _computerRepo = computerRepo;
            _componentRepo = componentRepo;
        }
        public Computer Create(ComputerViewModel createComputer)
        {
            Computer computer = _computerRepo.Create(new Computer { Name = createComputer.Name});
            List<int> componentsId = new List<int>();

            componentsId.Add(createComputer.CpuId);
            componentsId.Add(createComputer.GpuId);
            componentsId.Add(createComputer.MemoryId);
            componentsId.Add(createComputer.MotherboardId);

            foreach (int item in componentsId)
            {
                ComputerComponent component = new ComputerComponent() { ComputerId = computer.Id, ComponentId = item};
                computer.Components.Add(component);
            }
            _computerRepo.Update(computer);

            return computer;
        }
        public Computer FindById(int id)
        {
            return _computerRepo.Read(id);
        }

        public List<Computer> GetAll()
        {
            return _computerRepo.Read();
        }
        public void Edit(int id, ComputerViewModel editComputer)
        {
            Computer computer = _computerRepo.Read(id);

            if(computer != null)
            {
                computer.Name = editComputer.Name;
                _computerRepo.Update(computer);
            }
        }
        public void Remove(int id)
        {
            Computer computer = _computerRepo.Read(id);
            if(computer != null)
            {
                _computerRepo.Delete(computer);
            }
        }
        public List<Component> GetComputerComponents(int id) 
        {
            Computer computer = _computerRepo.Read(id);
            List<Component> components = new List<Component>();
            foreach(var item in computer.Components)
            {
                components.Add(_componentRepo.Read(item.ComponentId));
            }
            return components;
        }
    }
}
