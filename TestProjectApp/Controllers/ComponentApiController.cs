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
    [Route("api/components")]
    [ApiController]
    public class ComponentApiController : ControllerBase
    {
        private readonly IComponentService _componentService;
        public ComponentApiController(IComponentService componentService)
        {
            _componentService = componentService;
        }
        // GET: api/<ComponentApiController>
        [HttpGet]
        public IEnumerable<Component> Get()
        {
            return _componentService.GetAll();
        }

        // GET api/<ComponentApiController>/5
        [HttpGet("{id}")]
        public Component Get(int id)
        {
            return _componentService.FindById(id);
        }

        // POST api/<ComponentApiController>
        [HttpPost]
        public void Post([FromBody] ComponentViewModel createComponent)
        {
            Component component = _componentService.Create(createComponent);
            if (component != null)
            {
                Response.StatusCode = 201;
            }
            else
            {
            Response.StatusCode = 400;
            }
        }

        // PUT api/<ComponentApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ComponentViewModel editComponent)
        {
            _componentService.Edit(id, editComponent);
        }

        // DELETE api/<ComponentApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _componentService.Remove(id);
        }
    }
}
