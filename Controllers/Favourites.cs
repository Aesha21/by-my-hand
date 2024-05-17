using by_my_hand.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace by_my_hand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Favourites : ControllerBase
    {
        private readonly ApplicationDbcontext _context;
        public Favourites(ApplicationDbcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Favourites>>> GetAllAsync()
        {
            var favourites = await _context.favourites.ToListAsync();
            return Ok(favourites);
        }

        [HttpPost]
        public async Task<IActionResult> AdditemtofavouriteAsync(FavDto dto)
        { 
            var favourite = new Favourite
            {
                productid = dto.productid
            };
            await _context.favourites.AddAsync(favourite);
            _context.SaveChanges();
            return Ok(favourite);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFavouriteAsync(int id)
        {
            var favourite = await _context.favourites.SingleOrDefaultAsync(i => i.Id == id);
            if (favourite == null) { return NotFound($"no item found in list with id: {id}"); }


            _context.SaveChanges();
            return Ok(favourite);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavouriteAsync(int id)
        {
            var favourite = await _context.favourites.SingleOrDefaultAsync(i => i.Id == id);
            if (favourite == null) { return NotFound($"no item found in list with id: {id}"); }

            _context.favourites.Remove(favourite);
            _context.SaveChanges();
            return Ok(favourite);
        }


    }
}
