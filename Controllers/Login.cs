using by_my_hand.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace by_my_hand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Login : ControllerBase
    {
        private readonly ApplicationDbcontext _context;
        public Login(ApplicationDbcontext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> login([FromBody] LoginDto loginDto)
        {
            var buyer = await _context.Buyers.FirstOrDefaultAsync(b => b.Email == loginDto.Email);
            var seller = await _context.sellers.FirstOrDefaultAsync(b => b.Email == loginDto.Email);

            if (buyer == null)
            if (seller == null)
            {
                return BadRequest("Invalid email or password");
            }

            if (!VerifyPassword(loginDto.Password, buyer.Password))
            if (!VerifyPassword(loginDto.Password, seller.Password))

                {
                    return BadRequest("Invalid email or password");
            }

            

            return Ok("Login successful"); 
        }
        private bool VerifyPassword(string plainTextPassword, byte[] hashedPassword)
        {
            return plainTextPassword == Encoding.UTF8.GetString(hashedPassword);
        }

    }
}
