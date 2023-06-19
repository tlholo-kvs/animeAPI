using animeAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace animeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumberOfSeasonsController : ControllerBase
    {
        private readonly SimpleAnimeListContext _context;

        public NumberOfSeasonsController(SimpleAnimeListContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<NumberOfSeason>> Get()
        {
            return await _context.NumberOfSeasons.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> get(int id)
        {
            if (id < 1)
                return BadRequest();
        }
    }
}
