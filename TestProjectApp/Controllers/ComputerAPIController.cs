using Microsoft.AspNetCore.Identity;
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
    [Route("api/computers")]
    [ApiController]
    public class ComputerAPIController : ControllerBase
    {
        private readonly IComputerService _computerService;
        private readonly UserManager<ApplicationUser> _userManager;
        public ComputerAPIController(IComputerService computerService, UserManager<ApplicationUser> userManager)
        {
            _computerService = computerService;
            _userManager = userManager;
        }

        // GET: api/<ComputerAPIController>
        [HttpGet]
        public IEnumerable<Computer> Get()
        {
            return _computerService.GetAll();
        }

        // GET api/<ComputerAPIController>/5
        [HttpGet("{id}")]
        public Computer Get(int id)
        {
            return _computerService.FindById(id);
        }

        // POST api/<ComputerAPIController>
        [HttpPost]
        public async Task Post([FromBody] ComputerViewModel createComputer)
        {
            Computer computer = _computerService.Create(createComputer);
            ApplicationUser user = await _userManager.FindByIdAsync(createComputer.UserId);
            user.ComputerId = computer.Id;
            await _userManager.UpdateAsync(user);
            if (computer != null)
            {
                Response.StatusCode = 201;
            }
            else
            {
                Response.StatusCode = 400;
            }
        }

        // PUT api/<ComputerAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ComputerViewModel editComputer)
        {
            _computerService.Edit(id, editComputer);
        }

        // DELETE api/<ComputerAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _computerService.Remove(id);
        }

        [HttpGet("components/{id}")]
        public IEnumerable<Component> GetComponents(int id)
        {
            return _computerService.GetComputerComponents(id);
        }
    }
}
