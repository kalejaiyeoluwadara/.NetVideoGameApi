using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGameApi.Data;
using VideoGameApi.Models;

namespace VideoGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController(VideoGameDbContext context) : ControllerBase
    {
        private readonly VideoGameDbContext _context = context ;

        [HttpGet]
        public async Task<ActionResult<List<VideoGame>>> GetVideoGames()
        {
            return Ok(await _context.VideoGames
                .Include(g=>g.VideoGameDetails)
                .ToListAsync());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<List<VideoGame>>> GetVideoGameById(int id)
        {
            var game = await _context.VideoGames.FindAsync(id);
            if (game is null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<VideoGame>> AddNewGame(VideoGame newGame)
        {
            if (newGame is null)
                return BadRequest();


            _context.VideoGames.Add(newGame);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVideoGameById), new { id = newGame.Id }, newGame);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVideoGame(int id, VideoGame updatedGame)
        {
            var game = await _context.VideoGames.FindAsync(id);

            if (game is null)
            {
                return NotFound();
            }

            game.Title = updatedGame.Title;
            game.Publisher = updatedGame.Publisher;
            game.Developer = updatedGame.Developer;
            game.Platform = updatedGame.Platform;


            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteVideoGame(int id)
        {
            var game = await _context.VideoGames.FindAsync(id);
            if (game is null)
                return NotFound();


            _context.VideoGames.Remove(game);

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
