using System.ComponentModel;

namespace by_my_hand.Dtos
{
    public class BuyersDto
    {
        public required string FirstName { get; set; }


        public required string LastName { get; set; }


        public required string Location { get; set; }


        public required string Phone { get; set; }

        public required string Email { get; set; }
        
        public required byte[] Password { get; set; }

    }
}
