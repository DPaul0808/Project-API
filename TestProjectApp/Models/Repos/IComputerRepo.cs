using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProjectApp.Models.Repos
{
    public interface IComputerRepo
    {
        Computer Create(Computer computer);
        List<Computer> Read();
        Computer Read(int id);
        void Update(Computer computer);
        void Delete(Computer computer);
    }
}
