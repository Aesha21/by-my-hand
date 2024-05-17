using by_my_hand.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace by_my_hand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Rates : ControllerBase
    {
        private readonly ApplicationDbcontext _context;
        public Rates(ApplicationDbcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var rates = await _context.Rates.OrderBy(r => r.stars).ToListAsync();
            return Ok(rates);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(RatesDto dto)
        {
            var rate = new Rate
            {
                Name = dto.Name,
                Description = dto.Description,
                stars = dto.stars
            };
            await _context.Rates.AddAsync(rate);
            _context.SaveChanges();
            return Ok(rate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsyncs(int id, [FromBody] RatesDto dto)
        { 
            var rate = await _context.Rates.SingleOrDefaultAsync(r => r.Id == id);

            if (rate == null) { return NotFound($"no rate was found with id: {id}"); }

            rate.Name = dto.Name;
            rate.Description = dto.Description;
            rate.stars = dto.stars;
           

            _context.SaveChanges();
            return Ok(rate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsyncs(int id)
        {
            var rate = await _context.Rates.SingleOrDefaultAsync(r => r.Id == id);

            if (rate == null)
                return NotFound($"no rate was found with id: {id}");

            _context.Remove(rate);
            _context.SaveChanges();
            return Ok(rate);
        }

    }
}
