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
    [Route("api/features")]
    [ApiController]
    public class FeatureApiController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        public FeatureApiController(IFeatureService featureService)
        {
            _featureService = featureService;
        }
        // GET: api/<FeatureApiController>
        [HttpGet]
        public IEnumerable<Feature> Get()
        {
            return _featureService.GetAll();
        }

        // GET api/<FeatureApiController>/5
        [HttpGet("{id}")]
        public Feature Get(int id)
        {
            return _featureService.FindById(id);
        }

        // POST api/<FeatureApiController>
        [HttpPost]
        public void Post([FromBody] FeatureViewModel createFeature)
        {
            Feature feature = _featureService.Create(createFeature);
            if (feature!=null)
            {
                Response.StatusCode = 201;
            }
            else
            {
            Response.StatusCode = 400;
            }
        }

        // PUT api/<FeatureApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] FeatureViewModel editFeature)
        {
            _featureService.Edit(id, editFeature);
        }

        // DELETE api/<FeatureApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _featureService.Remove(id);
        }
    }
}
