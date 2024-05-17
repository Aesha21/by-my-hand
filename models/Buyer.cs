using System.ComponentModel.DataAnnotations.Schema;

namespace by_my_hand.models
{
    public class Buyer
    {
        public byte Id { get; set; }

        [MaxLength(50)]
        public required string FirstName { get; set; }

        [MaxLength(50)]
        public required string LastName { get; set; }

        [MaxLength(100)]
        public required string Location { get; set; }

        [MaxLength(50)]
        [DataType(DataType.Password)]
        public required byte[] Password { get; set; }

        public required string Phone { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        public byte[] photo { get; set; }

    }

}