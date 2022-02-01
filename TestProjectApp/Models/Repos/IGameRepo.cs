using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProjectApp.Models.Repos
{
    public interface IGameRepo
    {
        public Game Create(Game game);
        public List<Game> Read();
        public Game Read(int id);
        public void Update(Game game);
        public void Delete(Game game);
    }
}
