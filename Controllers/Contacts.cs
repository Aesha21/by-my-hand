using by_my_hand.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace by_my_hand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Contacts : ControllerBase
    {
        private readonly ApplicationDbcontext _context;
        public Contacts(ApplicationDbcontext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<Contact>> GetByIdAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound($"no contact was found with id: {id}");
            }
            return contact;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ContactsDto dto)
        {
            var contact = new Contact
            {
             description = dto.description,
             mail = dto.mail,
             
            };
            await _context.AddAsync(contact);
            _context.SaveChanges();
            return Ok(contact);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsyncs(int id, [FromBody] ContactsDto dto)
        {
       
            var contact = await _context.Contacts.SingleOrDefaultAsync(w => w.Id == id);

            if (contact == null) { return NotFound($"no contact was found with id: {id}"); }


          contact.mail = dto.mail;
            contact.description = dto.description;
            _context.SaveChanges();
            return Ok(contact);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsyncs(int id)
        {
            var contact = await _context.Contacts.SingleOrDefaultAsync(w => w.Id == id);

            if (contact == null)
                return NotFound($"no contact was found with id: {id}");

            _context.Remove(contact);
            _context.SaveChanges();
            return Ok(contact);
        }
    }
}
