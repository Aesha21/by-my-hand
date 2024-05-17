using by_my_hand.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace by_my_hand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Subs : ControllerBase
    {
        private readonly ApplicationDbcontext _context;
        public Subs(ApplicationDbcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var subs = await _context.Subs
                .OrderBy(s => s.Name)
                .Include(s => s.Group)
                .ToListAsync();
            return Ok(subs);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(SubsDto dto)
        {

            var sub = new Sub
            {
                Name = dto.Name,
                 Group = dto.Group,
            };

            await _context.AddAsync(sub);
            _context.SaveChanges();
            return Ok(sub);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsyncs(int id, [FromBody] SubsDto dto)
        {
            var sub = await _context.Subs.SingleOrDefaultAsync(s => s.Id == id);

            if (sub == null) { return NotFound($"no Subcategory was found with id: {id}"); }

            sub.Name = dto.Name;
            sub.Group = dto.Group;

            _context.SaveChanges();
            return Ok(sub);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsyncs(int id)
        {
            var sub = await _context.Subs.SingleOrDefaultAsync(s => s.Id == id);

            if (sub == null)
                return NotFound($"no Subcategory was found with id: {id}");

            _context.Remove(sub);
            _context.SaveChanges();
            return Ok(sub);
        }

    }
}
