﻿using animeAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace animeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DateReleasedController : ControllerBase
    {
        private readonly SimpleAnimeListContext _context;

        public DateReleasedController(SimpleAnimeListContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<DateReleased>> Get() 
        {
            return await _context.DateReleaseds.ToListAsync(); ;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) 
        {
            var dateReleased = await _context.DateReleaseds.FirstOrDefaultAsync(m => m.Id == id);
            if(dateReleased == null)
            {
                return NotFound();
            }

            return Ok(dateReleased);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DateReleased dateReleased)
        {
            _context.Add(dateReleased);

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(DateReleased dateReleasedData)
        {
            if (dateReleasedData == null || dateReleasedData.Id == 0)
                return BadRequest();

            var dateReleased = await _context.DateReleaseds.FindAsync(dateReleasedData.Id);
            if( dateReleased == null)
                return NotFound();

            dateReleased.FirstAiring = dateReleasedData.FirstAiring;

            await _context.SaveChangesAsync();

            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        {
            var dateReleased = await _context.DateReleaseds.FindAsync(id);
            if (dateReleased == null) return NotFound();

            _context.DateReleaseds.Remove(dateReleased);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}