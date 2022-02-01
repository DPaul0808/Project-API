using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProjectApp.Models;
using TestProjectApp.Models.Services;
using TestProjectApp.Models.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestProjectApp.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GameApiController : ControllerBase
    {
        private readonly IGameService _gameService;
        public GameApiController(IGameService gameService)
        {
            _gameService = gameService;
        }
        // GET: api/<GameApiController>
        [HttpGet]
        public IEnumerable<Game> Get()
        {
            return _gameService.GetAll();
        }

        // GET api/<GameApiController>/5
        [HttpGet("{id}")]
        public Game Get(int id)
        {
            return _gameService.FindById(id);
        }

        // POST api/<GameApiController>
        [HttpPost]
        public void Post([FromBody] GameViewModel createGame)
        {
            Game game = _gameService.Create(createGame);
            if (game != null)
            {
                Response.StatusCode = 201;
            }
            else
            {
                Response.StatusCode = 400;
            }
        }

        // PUT api/<GameApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] GameViewModel editGame)
        {
            _gameService.Edit(id, editGame);
        }

        // DELETE api/<GameApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _gameService.Remove(id);
        }
    }
}
