using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProjectApp.Models.Data;

namespace TestProjectApp.Models.Repos
{
    public class GameDbRepo : IGameRepo
    {
        private readonly ProjectDbContext _projectDb;
        public GameDbRepo(ProjectDbContext projectDb)
        {
            _projectDb = projectDb;
        }
        public Game Create(Game game)
        {
            _projectDb.Games.Add(game);
            _projectDb.SaveChanges();

            return game;
        }


        public List<Game> Read()
        {
            return _projectDb.Games.ToList();
        }

        public Game Read(int id)
        {
            return _projectDb.Games.Include(g => g.Features).Single(g => g.Id == id);
        }

        public void Update(Game game)
        {
            _projectDb.Games.Update(game);
            _projectDb.SaveChanges();
        }
        public void Delete(Game game)
        {
            _projectDb.Games.Remove(game);
            _projectDb.SaveChanges();
        }
    }
}
