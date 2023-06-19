using animeAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace animeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumberOfEpisodesController : ControllerBase
    {
        private readonly SimpleAnimeListContext _context;   

        public NumberOfEpisodesController(SimpleAnimeListContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<NumberOfEpisode>> Get()
        {
            return await _context.NumberOfEpisodes.ToListAsync();   
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1)
                return BadRequest();

            var episode = await _context.NumberOfEpisodes.FirstOrDefaultAsync();
            if(episode == null)
                return NotFound();

            return Ok(episode);
        }

        [HttpPost]
        public async Task<IActionResult> Post(NumberOfEpisode numberOfEpisode)
        {
            _context.Add(numberOfEpisode);
            await _context.SaveChangesAsync();  

            return Ok();
        }
    }
}
