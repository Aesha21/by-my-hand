using Microsoft.EntityFrameworkCore;
namespace by_my_hand.models
{
    public class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext>options): base(options)
        {
        }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Sub> Subs { get; set; }
        public DbSet<Rate> Rates { get; set; }

        public DbSet<Ware> Wares { get; set; } 

        public DbSet<Address> Addresses{ get; set; }

        public DbSet<Buyer> Buyers{ get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Credit> Credits { get; set; }

        public DbSet<Order> Orders{ get; set; }

        public DbSet<Cart> carts { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Favourite> favourites { get; set; }

        public DbSet<Seller> sellers { get; set; }

    }
}
