using by_my_hand.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace by_my_hand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Wares : ControllerBase
    {
        private readonly ApplicationDbcontext _context;
        public Wares(ApplicationDbcontext context)
        {
            _context = context;
        }
        
        //retrieves and returns all wares
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var wares = await _context.Wares
                .OrderBy(s => s.rate)
                .ToListAsync();
            return Ok(wares);
        }
        
        [HttpGet("{id}")]
        //retrieve one ware detials
        public async Task<ActionResult<Ware>> GetByIdAsync(int id)
        {
            var ware = await _context.Wares.FindAsync(id);
            if (ware == null)
            {
                return NotFound($"no product was found with id: {id}"); 
            }
            return ware;
        }
        
        //search ware
        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<Ware>>> SearchAsync(string keyword,
           string filter,
           int? minPrice = 100,
           int? maxPrice = 500,
           int? minReviewRating = 1)
        {
            var query = _context.Wares.AsQueryable(); 

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(w => w.Name.ToLower().Contains(keyword.ToLower()) || w.Description.ToLower().Contains(keyword.ToLower()));
            }
            //filter by goup
            if (!string.IsNullOrEmpty(filter))
            {
                if (filter == "group1")
                {
                    query = query.Where(w => w.group == "group 1");
                }
                else if (filter == "group1")
                {
                    query = query.Where(w => w.group == "group 2");
                }
            }
            // Filter by price range
            if (minPrice.HasValue)
            {
                query = query.Where(w => w.price >= minPrice);
            }
            if (maxPrice.HasValue)
            {
                query = query.Where(w => w.price <= maxPrice);
            }

            // Filter by minimum review rating
            if (minReviewRating.HasValue)
            {
                query = query.Where(w => w.rate >= minReviewRating);
            }
        var results = await query.ToListAsync();
            return Ok(results);
        }
        

        [HttpPost]
        public async Task<IActionResult> CreateAsync(WaresDto dto)
        {
            var ware = new Ware
            {
                Name = dto.Name,
                Description = dto.Description,
                price = dto.Price,
                quantity = dto.Quantity,
                size = dto.Size,
                color = dto.Color,
                 group = dto.Group,
                 rate = dto.Rate
            };
            await _context.AddAsync(ware);
            _context.SaveChanges();
            return Ok(ware);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsyncs(int id, [FromBody] WaresDto dto)
        {
            var ware = await _context.Wares.SingleOrDefaultAsync(w => w.Id == id);

            if (ware == null) { return NotFound($"no product was found with id: {id}"); }

            ware.Name = dto.Name;
            ware.price = dto.Price;
            ware.group = dto.Group;
            ware.rate = dto.Rate;
            ware.size = dto.Size;
            ware.quantity = dto.Quantity;
            ware.Description = dto.Description;
            ware.color = dto.Color;

            _context.SaveChanges();
            return Ok(ware);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsyncs(int id)
        {
            var ware = await _context.Wares.SingleOrDefaultAsync(w => w.Id == id);

            if (ware == null)
                return NotFound($"no product was found with id: {id}");

            _context.Remove(ware);
            _context.SaveChanges();
            return Ok(ware);
        }

    }
}
