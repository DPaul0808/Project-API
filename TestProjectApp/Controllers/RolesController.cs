using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProjectApp.Models;
using TestProjectApp.Models.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestProjectApp.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        UserManager<ApplicationUser> _userManager;
        RoleManager<IdentityRole> _roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: api/<RolesController>
        [HttpGet]
        public IEnumerable<IdentityRole> Get()
        {
            return _roleManager.Roles.ToList();
        }

        // GET api/<RolesController>/5
        [HttpGet("{id}")]
        public async Task<List<ApplicationUser>> GetUsersWithRole(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);

            return (List<ApplicationUser>)await _userManager.GetUsersInRoleAsync(role.Name);
        }
        [HttpGet("notInRole/{id}")]
        public async Task<List<ApplicationUser>> GetUsersWithoutRole(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            List<ApplicationUser> userInRole = (List<ApplicationUser>)await _userManager.GetUsersInRoleAsync(role.Name);
            List<ApplicationUser> users = _userManager.Users.ToList();
            foreach (var item in _userManager.Users.ToList())
            {
                if (userInRole.Contains(item))
                {
                    users.Remove(item);
                }
            }

            return (List<ApplicationUser>)users;
        }

        // POST api/<RolesController>
        [HttpPost]
        public async Task Post([FromBody] RoleViewModel addRole)
        {
            IdentityRole role = new IdentityRole(addRole.Name);

            await _roleManager.CreateAsync(role);

        }

        [HttpPost("addUser")]
        public async Task Post([FromBody] AddRemoveRoleViewModel addUser)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(addUser.roleId);
            ApplicationUser user = await _userManager.FindByIdAsync(addUser.userId);
            await _userManager.AddToRoleAsync(user, role.Name);
        }

        // PUT api/<RolesController>/5
        [HttpPut("{id}")]
        public async Task Put(string id, [FromBody] RoleViewModel editRole)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            role.Name = editRole.Name;
            await _roleManager.UpdateAsync(role);
        }

        //DELETE api/<RolesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            await _roleManager.DeleteAsync(role);
        }
        [HttpDelete("removeUser")]
        public async Task Delete([FromBody] AddRemoveRoleViewModel removeUser)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(removeUser.roleId);
            ApplicationUser user = await _userManager.FindByIdAsync(removeUser.userId);
            await _userManager.RemoveFromRoleAsync(user, role.Name);
        }
    }
}
