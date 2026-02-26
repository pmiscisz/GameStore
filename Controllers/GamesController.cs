using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameStore.Models;
using System.Diagnostics.Eventing.Reader;
using GameStore.Data;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        
        private readonly GameStoreContext _context;

        public GamesController(GameStoreContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task <ActionResult<List<Game>>> GetGames()
        {
            return Ok(await _context.Games.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task <ActionResult<Game>> GetGame(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
                return NotFound();
            else
                return Ok(game);
        }

        [HttpPost]

        public async Task<ActionResult<Game>> AddGame(Game newGame)
        {
            if (newGame == null)
                return BadRequest();

            _context.Games.Add(newGame);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetGame), new { id = newGame.Id }, newGame);
        }

        [HttpPut("{id}")]
        public async Task <IActionResult> UpdateGame(int id, Game updatedGame)
        {
            var game = await _context.Games.FindAsync(id);

            if (game == null)
                return NotFound();

            game.Title = updatedGame.Title;
            game.Developer = updatedGame.Developer;
            game.Price = updatedGame.Price;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
                return NotFound();

            _context.Remove(game);

            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
}
