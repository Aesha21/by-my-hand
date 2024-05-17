namespace by_my_hand.Dtos
{
    public class CreditsDto
    {
        public required string HolderName { get; set; }

        public required string CardNumber { get; set; }

        public int CVV { get; set; }
        public DateTime ExpiryDate { get; set; }

    }
}
