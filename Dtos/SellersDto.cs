namespace by_my_hand.Dtos
{
    public class SellersDto
    {
        public int id { get; set; }
        public required string FullName { get; set; }
        public int nationalId { get; set; }
        public required string Phone { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        public required string BusinessName { get; set; }
        public required string BusinessType { get; set; }
        public required string BusinessAddress { get; set; }
        public required string UserName { get; set; }
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public required byte[] Password { get; set; }
        public int taxId { get; set; }
        public required string SocialsLinks { get; set; }
        public required string TypeOfProduct { get; set; }
        public required string PaymentType { get; set; }
        public required string Pricing { get; set; }
        public required string Description { get; set; }
        public required string ShippingMedthod { get; set; }
        public int ShippingCost { get; set; }
        public required string Estimated { get; set; }
    }
}
