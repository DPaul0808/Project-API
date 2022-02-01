using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProjectApp.Models.Repos;
using TestProjectApp.Models.ViewModels;

namespace TestProjectApp.Models.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepo _gameRepo;
        public GameService(IGameRepo gameRepo)
        {
            _gameRepo = gameRepo;
        }
        public Game Create(GameViewModel createGame)
        {
            return _gameRepo.Create(new Game()
            {
                Name = createGame.Name,
                Description = createGame.Description
            });
        }

        public List<Game> GetAll()
        {
            return _gameRepo.Read();
        }

        public Game FindById(int id)
        {
            return _gameRepo.Read(id);
        }

        public void Edit(int id, GameViewModel editGame)
        {
            Game game = _gameRepo.Read(id);
            if (game != null)
            {
                game.Name = editGame.Name;
                game.Description = editGame.Description;
                _gameRepo.Update(game);
            }
        }

        public void Remove(int id)
        {
            Game game = _gameRepo.Read(id);
            if (game != null)
            {
                _gameRepo.Delete(game);
            }
        }
        public void CanItRun(int computerId, int gameId)
        {

        }
    }
}
