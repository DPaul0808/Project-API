using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProjectApp.Models.ViewModels;

namespace TestProjectApp.Models.Services
{
    public interface IGameService
    {
        public Game Create(GameViewModel createGame);
        public List<Game> GetAll();
        public Game FindById(int id);
        public void Edit(int id, GameViewModel editGame);
        public void Remove(int id);


    }
}
