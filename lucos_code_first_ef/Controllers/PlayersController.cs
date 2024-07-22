using AutoMapper;
using lucos_code_first_ef.Data;
using lucos_code_first_ef.Dto;
using lucos_code_first_ef.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lucos_code_first_ef.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PlayersController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET /api/Players
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerDTO>>> GetPlayers()
        {
            var players = await _context.Players.ToListAsync();
            var playerDTOs = _mapper.Map<List<PlayerDTO>>(players);
            return playerDTOs;
        }

        // GET /api/Players/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerDTO>> GetPlayer(Guid id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            var playerDTO = _mapper.Map<PlayerDTO>(player);
            return playerDTO;
        }

        // POST /api/Players
        [HttpPost]
        public async Task<ActionResult<PlayerDTO>> PostPlayer([FromBody] PlayerDTO playerDTO)
        {
            var player = _mapper.Map<Player>(playerDTO);
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
            playerDTO.Id = player.Id;
            return CreatedAtAction(nameof(GetPlayer), new { id = player.Id }, playerDTO);
        }

        // PUT /api/Players/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(Guid id, [FromBody] PlayerDTO playerDTO)
        {
            if (id != playerDTO.Id)
            {
                return BadRequest();
            }

            var existingPlayer = await _context.Players.FindAsync(id);
            if (existingPlayer == null)
            {
                return NotFound();
            }

            _mapper.Map(playerDTO, existingPlayer);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
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

        // DELETE /api/Players/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(Guid id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool PlayerExists(Guid id)
        {
            return _context.Players.Any(e => e.Id == id);
        }
    }
}