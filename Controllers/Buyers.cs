using by_my_hand.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace by_my_hand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Buyers : ControllerBase
    {
        private readonly ApplicationDbcontext _context;
        public Buyers(ApplicationDbcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Buyer>> GetByIdAsync(int id)
        {
            var buyer = await _context.Buyers.FindAsync(id);
            if (buyer == null)
            {
                return NotFound($"no buyer was found with id: {id}");
            }
            return Ok(buyer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(BuyersDto dto)
        {
            var buyer = new Buyer
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Location = dto.Location,
                Phone = dto.Phone,
                Email = dto.Email,
                Password = dto.Password,
            };
            await _context.AddAsync(buyer);
            _context.SaveChanges();
            return Ok(buyer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsyncs(int id, [FromBody] BuyersDto dto)
        {
            var buyer = await _context.Buyers.SingleOrDefaultAsync(w => w.Id == id);

            if (buyer == null) { return NotFound($"no buyer was found with id: {id}"); }

       
            buyer.Email = dto.Email;
            buyer.FirstName = dto.FirstName;
            buyer.LastName = dto.LastName;
            buyer.Location = dto.Location;
            buyer.Phone = dto.Phone;
            buyer.Password = dto.Password;
            _context.SaveChanges();
            return Ok(buyer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsyncs(int id)
        {
            var buyer = await _context.Buyers.SingleOrDefaultAsync(w => w.Id == id);

            if (buyer == null)
                return NotFound($"no buyer was found with id: {id}");

            _context.Remove(buyer);
            _context.SaveChanges();
            return Ok(buyer);
        }
    }
}
