using by_my_hand.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace by_my_hand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Orders : ControllerBase
    {
        private readonly ApplicationDbcontext _context;
        public Orders(ApplicationDbcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Order>> GetByIdAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound($"no order was found with id: {id}");
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(OrdersDto dto)
        {
            var order = new Order
            {
                Description = dto.Description,
                Price = dto.Price,
                ProductName = dto.ProductName,
                Quantity = dto.Quantity,
                OrderStatus = dto.OrderStatus,
                PaymentType = dto.PaymentType,

            };
            await _context.AddAsync(order);
            _context.SaveChanges();
            return Ok(order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsyncs(int id, [FromBody] OrdersDto dto)
        {
            var order = await _context.Orders.SingleOrDefaultAsync(w => w.Id == id);

            if (order == null) { return NotFound($"no order was found with id: {id}"); }

            order.ProductName = dto.ProductName;
            order.Quantity = dto.Quantity;
            order.Price = dto.Price;
            order.Description = dto.Description;
            order.OrderStatus = dto.OrderStatus;
            order.PaymentType = dto.PaymentType;
            
            _context.SaveChanges();
            return Ok(order);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsyncs(int id)
        {
            var order = await _context.Orders.SingleOrDefaultAsync(w => w.Id == id);

            if (order == null)
                return NotFound($"no order was found with id: {id}");

            _context.Remove(order);
            _context.SaveChanges();
            return Ok(order);
        }
    }
}
