using Microsoft.AspNetCore.Mvc;

namespace VideoGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        static private List<VideoGame> videoGames = new List<VideoGame>
        {
            new VideoGame
            {
                Id = 1,
                Title = "Spider-Man 2",
                Platform = "ps 5",
                Developer = "Insomniac Games",
                Publisher = "Sony Interactive Entertainment"
            }
        };

        [HttpGet]
        public ActionResult<List<VideoGame>> GetVideoGames()
        {
            return Ok(videoGames);
        }


        [HttpGet("{id}")]
        public ActionResult<List<VideoGame>> GetVideoGameById(int id)
        {
            var game = videoGames.FirstOrDefault(x => x.Id == id);
            if(game is null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        [HttpPost]
        public ActionResult<VideoGame> AddNewGame(VideoGame newGame)
        {
            if (newGame is null)
                return BadRequest();


            newGame.Id = videoGames.Max(g => g.Id) + 1;
            return CreatedAtAction(nameof(GetVideoGameById),  new { id= newGame.Id },newGame);
        }

        [HttpPut]
        public IActionResult UpdateVideoGame(int id, VideoGame updatedGame)
        {
            var game = videoGames.FirstOrDefault(game => game.Id == id);

            if(game is null)
            {
                return NotFound();
            }

            game.Title = updatedGame.Title;
            game.Publisher = updatedGame.Publisher;
            game.Developer = updatedGame.Developer;
            game.Platform = updatedGame.Platform;

            return NoContent();
        }


        [HttpDelete]
        public IActionResult DeleteVideoGame(int id)
        {
            var game = videoGames.FirstOrDefault(game => game.Id == id);
            if (game is null)
                return  NotFound();
            videoGames.Remove(game);
            return NoContent();
        }
    }
}
