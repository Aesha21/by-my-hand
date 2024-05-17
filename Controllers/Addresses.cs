using by_my_hand.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace by_my_hand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Addresses : ControllerBase
    {
        private readonly ApplicationDbcontext _context;
        public Addresses(ApplicationDbcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var addresses = await _context.Addresses.ToListAsync();
            return Ok(addresses);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(AddressesDto dto)
        {
            var address = new Address
            {
             ClientName = dto.ClientName,
             City = dto.City,
             Street = dto.Street,
             PhoneNumber = dto.PhoneNumber,
             Building = dto.Building,
             Landmark = dto.Landmark,
             AddressType = dto.AddressType,
            };
            await _context.Addresses.AddAsync(address);
            _context.SaveChanges();
            return Ok(address);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsyncs(int id, [FromBody] AddressesDto dto)
        {
            var address = await _context.Addresses.SingleOrDefaultAsync(a => a.Id == id);

            if (address == null) { return NotFound($"no address was found with id: {id}"); }

            address.Street = dto.Street;
            address.PhoneNumber = dto.PhoneNumber;
            address.Building = dto.Building;
            address.Landmark = dto.Landmark;
            address.ClientName = dto.ClientName;
            address.AddressType = dto.AddressType;

            _context.SaveChanges();
            return Ok(address);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsyncs(int id)
        {
            var address = await _context.Addresses.SingleOrDefaultAsync(a => a.Id == id);

            if (address == null)
                return NotFound($"no address was found with id: {id}");

            _context.Remove(address);
            _context.SaveChanges();
            return Ok(address);
        }
    }
}
