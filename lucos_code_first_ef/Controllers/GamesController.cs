using lucos_code_first_ef.Data;
using lucos_code_first_ef.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lucos_code_first_ef.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly DataContext _context;

        public GamesController(DataContext context)
        {
            _context = context; 
        }

        // GET /api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGames()
        {
            return await _context.Games
                .Include(g => g.PlayerW)
                .Include(g => g.PlayerB)
                .Include(g => g.Opening)
                .ToListAsync();
        }

        // GET /api/Games/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(Guid id)
        {
            var game = await _context.Games
                .Include(g => g.PlayerW)
                .Include(g => g.PlayerB)
                .Include(g => g.Opening)
                .FirstOrDefaultAsync(g => g.Id == id);
            if (game == null)
            { 
                return NotFound();
            }
            return game;
        }

        // POST /api/Games
        [HttpPost]
        public async Task<ActionResult<Game>> PostGame([FromBody] Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetGame), new { id = game.Id }, game);
        }

        // PUT /api/Games/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(Guid id, [FromBody] Game game)
        {
            if (id != game.Id)
            {
                return BadRequest();
            }

            var existingGame = await _context.Games
                .Include(g => g.PlayerW)
                .Include(g => g.PlayerB)
                .Include(g => g.Opening)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (existingGame == null)
            {
                return NotFound();
            }

            // Update the main game properties
            existingGame.Date = game.Date;
            existingGame.Result = game.Result;

            // Update the PlayerW entity
            if (game.PlayerW != null)
            {
                _context.Entry(existingGame.PlayerW).CurrentValues.SetValues(game.PlayerW);
            }

            // Update the PlayerB entity
            if (game.PlayerB != null)
            {
                _context.Entry(existingGame.PlayerB).CurrentValues.SetValues(game.PlayerB);
            }

            // Update the Opening entity
            if (game.Opening != null)
            {
                _context.Entry(existingGame.Opening).CurrentValues.SetValues(game.Opening);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }


        // DELETE /api/Games/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(Guid id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool GameExists(Guid id)
        {
            return _context.Games.Any(e => e.Id == id);
        }
    }
}
