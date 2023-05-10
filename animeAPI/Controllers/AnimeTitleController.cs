using animeAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace animeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimeTitleController : ControllerBase
    {
        private readonly SimpleAnimeListContext _context;

        public AnimeTitleController(SimpleAnimeListContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<AnimeTitle>> GetAnimeTitles()
        {
            return await _context.AnimeTitles.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnimeTitle>> GetAnimeTitle(int id)
        {
            var animeTitle = await _context.AnimeTitles.FirstOrDefaultAsync(m => m.Id == id);

            if (animeTitle == null) {
                return NotFound();
            }

            return Ok(animeTitle);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AnimeTitle animeTitle)
        {
            _context.Add(animeTitle);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutAnimeTitle(AnimeTitle animeTitleData)
        {
            if (animeTitleData == null || animeTitleData.Id == 0) 
            {
                return BadRequest();    
            }

            var animeTitle = await _context.AnimeTitles.FindAsync(animeTitleData.Id);
            if (animeTitle == null) 
            {
                return NotFound();
            }

            animeTitle.Name = animeTitleData.Name;
            animeTitle.Id = animeTitleData.Id;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var animeTitle = await _context.AnimeTitles.FindAsync(id);

            if(animeTitle == null)  return NotFound();

            _context.AnimeTitles.Remove(animeTitle);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
