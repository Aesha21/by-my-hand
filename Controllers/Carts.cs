using by_my_hand.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace by_my_hand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Carts : ControllerBase
    {
        private readonly ApplicationDbcontext _context;
        public Carts(ApplicationDbcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetAllAsync()
        {
            var cartItems = await _context.CartItems.ToListAsync();
            return Ok(cartItems);
        }

        [HttpPost]
        public async Task<IActionResult> AddItemToCartAsync(CartItems dto)
        {
            var cartItem = new CartItem
            {
                productid = dto.productid,
                quantitty = dto.quantitty
            };
            await _context.CartItems.AddAsync(cartItem);
            _context.SaveChanges();
            return Ok(cartItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCartItemAsync(int id, CartItems dto)
        {
            var cartItem = await _context.CartItems.SingleOrDefaultAsync(i => i.Id == id);
            if (cartItem == null) { return NotFound($"no item found in cart with id: {id}"); }

            cartItem.quantitty = dto.quantitty;
            _context.SaveChanges();
            return Ok(cartItem);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItemAsync(int id)
        {
            var cartItem = await _context.CartItems.SingleOrDefaultAsync(i => i.Id == id);
            if (cartItem == null) { return NotFound($"no item found in cart with id: {id}"); }

            _context.CartItems.Remove(cartItem);
            _context.SaveChanges();
            return Ok(cartItem);
        }

    }
}
