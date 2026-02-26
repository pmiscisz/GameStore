using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameStore.Models;
using GameStore.Data;
using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly GameStoreContext _context;

        public UsersController(GameStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return Ok(await _context.Users.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return NoContent();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> PostUser(User newUser)
        {
            if(newUser == null)
                return BadRequest();
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser),new { id = newUser.Id }, newUser);

        }

        [HttpPut("{id}")]
        public async Task <ActionResult> UpdateUser(int id, User updatedUser)
        {
            var user = await _context.Users.FindAsync(id);
            if(user == null)
                return NoContent();

            user.UserName = updatedUser.UserName;
            user.Email = updatedUser.Email;
            user.UserPermission = updatedUser.UserPermission;
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task <ActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            
            if(user == null)
                return BadRequest();
            _context.Remove(user);
            await _context.SaveChangesAsync();

            return Ok("User was deleted");
        }

    }
}
