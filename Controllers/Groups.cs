using by_my_hand.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace by_my_hand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Groups : ControllerBase
    {
        
        private readonly ApplicationDbcontext _context;
        public Groups(ApplicationDbcontext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var groups = await _context.Groups.OrderBy(g => g.Name).ToListAsync();
            return Ok(groups);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateAsync(GroupsDto dto)
        {
            var group = new Group
            {
                Name = dto.Name,
            };
            await _context.Groups.AddAsync(group);
            _context.SaveChanges();
            return Ok(group);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsyncs(int id, [FromBody] GroupsDto dto)
        {
            var group = await _context.Groups.SingleOrDefaultAsync(g => g.Id == id);

            if (group == null) { return NotFound($"no category was found with id: {id}"); }

            group.Name = dto.Name;

            _context.SaveChanges();
            return Ok(group);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsyncs(int id)
        {
            var group = await _context.Groups.SingleOrDefaultAsync(g => g.Id == id);

            if (group == null)
                return NotFound($"no category was found with id: {id}");

            _context.Remove(group);
            _context.SaveChanges();
            return Ok(group);
        }
        

    }
}
