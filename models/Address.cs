namespace by_my_hand.models
{
    public class Address
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public required string ClientName { get; set; }
        
        [MaxLength(100)]
        public required string Street { get; set; }

        [MaxLength(50)]
        public required string City { get; set; }

        public required string PhoneNumber { get; set; }

        [MaxLength(50)]
        public required string Building { get; set; }

       [MaxLength(100)]
        public required string Landmark { get; set; }

       public required string AddressType { get; set; }

    }
}