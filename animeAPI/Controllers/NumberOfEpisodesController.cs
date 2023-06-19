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


    }
}
