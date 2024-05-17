using by_my_hand.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace by_my_hand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Sellers : ControllerBase
    {
        private readonly ApplicationDbcontext _context;
        public Sellers(ApplicationDbcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Seller>> GetByIdAsync(int id)
        {
            var seller = await _context.sellers.FindAsync(id);
            if (seller == null)
            {
                return NotFound($"no seller was found with id: {id}");
            }
            return Ok(seller);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(SellersDto dto)
        {
            var seller = new Seller
            {
                FullName = dto.FullName,
                Description = dto.Description,
                Phone = dto.Phone,
                Email = dto.Email,
                nationalId = dto.nationalId,
                BusinessAddress = dto.BusinessAddress,
                BusinessName = dto.BusinessName,
                BusinessType = dto.BusinessType,
                UserName = dto.UserName,
                Password = dto.Password,
                taxId = dto.taxId,
                SocialsLinks = dto.SocialsLinks,
                TypeOfProduct = dto.TypeOfProduct,
                PaymentType = dto.PaymentType,
                Pricing = dto.Pricing,
                ShippingCost = dto.ShippingCost,
                ShippingMedthod = dto.ShippingMedthod,
                Estimated = dto.Estimated
 
    };
            await _context.AddAsync(seller);
            _context.SaveChanges();
            return Ok(seller);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsyncs(int id, [FromBody] SellersDto dto)
        {
            var seller = await _context.sellers.SingleOrDefaultAsync(w => w.id == id);

            if (seller == null) { return NotFound($"no seller was found with id: {id}"); }


            seller.TypeOfProduct = dto.TypeOfProduct;
            seller.ShippingMedthod = dto.ShippingMedthod;
            seller.BusinessAddress = dto.BusinessAddress;
            seller.BusinessName = dto.BusinessName;
            seller.Email = dto.Email;
            seller.Estimated = dto.Estimated;
            seller.BusinessType = dto.BusinessType;
            seller.Description = dto.Description;
            seller.FullName = dto.FullName;
            seller.Password = dto.Password;
            seller.SocialsLinks = dto.SocialsLinks;
            seller.PaymentType = dto.PaymentType;
            seller.nationalId = dto.nationalId;
            seller.Phone = dto.Phone;
            seller.Pricing = dto.Pricing;
            seller.UserName = dto.UserName;
            seller.taxId = dto.taxId;

            _context.SaveChanges();
            return Ok(seller);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsyncs(int id)
        {
            var seller = await _context.sellers.SingleOrDefaultAsync(w => w.id == id);

            if (seller == null)
                return NotFound($"no seller was found with id: {id}");

            _context.Remove(seller);
            _context.SaveChanges();
            return Ok(seller);
        }
    }
}
