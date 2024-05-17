using by_my_hand.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace by_my_hand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Credits : ControllerBase
    {
        private readonly ApplicationDbcontext _context;
        public Credits(ApplicationDbcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Credits>> GetByIdAsync(int id)
        {
            var credit = await _context.Credits.FindAsync(id);
            if (credit == null)
            {
                return NotFound($"no credit was found with id: {id}");
            }
            return Ok(credit);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreditsDto dto)
        {
            var credit = new Credit
            {
              CVV = dto.CVV,
              ExpiryDate = dto.ExpiryDate,
              CardNumber = dto.CardNumber,
              HolderName = dto.HolderName,

            };
            await _context.AddAsync(credit);
            _context.SaveChanges();
            return Ok(credit);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsyncs(int id, [FromBody] CreditsDto dto)
        {

            var credit = await _context.Credits.SingleOrDefaultAsync(w => w.Id == id);

            if (credit == null) { return NotFound($"no credit was found with id: {id}"); }

           credit.CVV = dto.CVV;
            credit.ExpiryDate = dto.ExpiryDate;
            credit.CardNumber = dto.CardNumber;
            credit.HolderName = dto.HolderName;

            _context.SaveChanges();
            return Ok(credit);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsyncs(int id)
        {
            var credit = await _context.Credits.SingleOrDefaultAsync(w => w.Id == id);

            if (credit == null)
                return NotFound($"no credit was found with id: {id}");

            _context.Remove(credit);
            _context.SaveChanges();
            return Ok(credit);
        }
    }
}
